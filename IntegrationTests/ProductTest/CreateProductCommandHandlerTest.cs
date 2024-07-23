using Application.Products.CreateProduct;
using Application.Products.DeletProduct;
using Application.Products.UpdateProduct;
using Application.Users.Create;
using Application.Users.UpdateUser;
using Domain.Products;
using Domain.Products.Repository;
using Domain.Users;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.ProductTest
{
    public class CreateProductCommandHandlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;


        public CreateProductCommandHandlerTest(DbContextFixture fixture)
        {

            _fixture = fixture;
        }

        [Fact]
        public async Task Handler_Should_Create_Product()
        {
            //arrange
            string dbName = Guid.NewGuid().ToString();

            var repo = new ProductRepositories(_fixture.BuildDbContext(dbName));
            var categoyRepo = new CategoryRepositories(_fixture.BuildDbContext(dbName));
            var handel = new CreateProductCommandHandler(repo, categoyRepo);

            var category = Category.Create("مبایل ");

            categoyRepo.Create(category);

            //act 

            var command = new CreateProductCommand("2694_msda", "سامسوگ A50", category.Id);

            var result = await handel.Handle(command, CancellationToken.None);

            //assert

            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);

            var product = repo.GetById(result.Id);
            product.Should().NotBeNull();
            product.Title.Should().Be(command.Title);
            product.CategoryId.Should().Be(category.Id);

        }


        [Fact]
        public async Task Handler_Should_Throw_Exception_If_Category_NotFound()
        {
            //arrange
            string dbName = Guid.NewGuid().ToString();

            var repo = new ProductRepositories(_fixture.BuildDbContext(dbName));
            var categoyRepo = new CategoryRepositories(_fixture.BuildDbContext(dbName));
            var handel = new CreateProductCommandHandler(repo, categoyRepo);

            //act 

            var command = new CreateProductCommand("2694_msda", "سامسوگ A50", 68768);

            Func<Task> act = async () => await handel.Handle(command, CancellationToken.None);

            //assert

            await act.Should().ThrowAsync<NullReferenceException>();


        }


        [Fact]
        public async Task Handle_Should_Update_Product()
        {
            string dbName = Guid.NewGuid().ToString();
            var repo = new ProductRepositories(_fixture.BuildDbContext(dbName));
            var product = Product.Create("10MP", "کفش زنانه", 5);
            var prucutId = repo.Create(product);

            var Command = new UpdateProductCommand(prucutId, "20Pm", "لباش مردانه", 5);
            var handler = new UpdateProductCommandHandler(repo);


             await handler.Handle(Command, CancellationToken.None);

            product.Id.Should().BeGreaterThan(0);
            product.Title.Should().NotBe("کفش زنانه");
            product.Title.Should().Be("لباش مردانه");
        }

        [Fact]
        public async Task Handle_Should_Delete_Product()
        {
            string dbName = Guid.NewGuid().ToString();
            var dbContext = _fixture.BuildDbContext(dbName);
            var repo = new ProductRepositories(dbContext);

            var product = Product.Create("10MP", "کفش زنانه", 5);
            var prucutId = repo.Create(product);

            var command = new DeleteProductCommand(prucutId);
            var handler = new DeleteProductCommandHandler(repo);

            await handler.Handle(command, CancellationToken.None);


            var deletedUser = repo.GetById(prucutId);
            deletedUser.Should().BeNull();

        }
    }
}
