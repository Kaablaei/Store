using Application.Products.CreateProduct;
using Application.Users.Create;
using Domain.Products.Repository;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
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
        public async Task Handle_Should_Create_Product()
        {
            //arrange
            string dbName = Guid.NewGuid().ToString();
            string dbNameForCategory = Guid.NewGuid().ToString();

             


            var repo = new ProductRepositories(_fixture.BuildDbContext(dbName));
            var categoyRepo = new CategoryRepositories(_fixture.BuildDbContext(dbName));
            var handel = new CreateProductCommandHandler(repo, categoyRepo);

            //act 

            var command = new CreateProductCommand("2694_msda","سامسوگ A50", 100.56m, 12);

            var result = await handel.Handle(command, CancellationToken.None);


            //assert

            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            var product = repo.GetById(result.Id);
            product.Should().NotBeNull();
            product.Title.Should().Be(command.Title);


        }
    }
}
