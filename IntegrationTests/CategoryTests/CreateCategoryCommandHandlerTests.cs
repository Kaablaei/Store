using Application.Carts.DeleteCart;
using Application.Carts.UpdateCart;
using Application.Categories.DeleteCategory;
using Application.Categories.UpdateCategory;
using Application.Categorys.CreateCategory;
using Application.Users.DeleteUser;
using Application.Users.UpdateUser;
using Domain.Products;
using Domain.Users;
using FluentAssertions;
using Infrastructure;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IntegrationTests.CategoryTests
{
    public class CreateCategoryCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        private readonly IThirdParty _thirdParty;


        public CreateCategoryCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
            _thirdParty = NSubstitute.Substitute.For<IThirdParty>();
        }


        [Fact]
        public async Task Handle_Should_Create_Category()
        {

            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repo = new CategoryRepositories(_fixture.BuildDbContext(dbName));

            var handler = new CreateCategoryCommandHandler(repo);
            //_thirdParty.SendSMS(Arg.Any<int>(), CancellationToken.None).Returns(3);
            //act



            var command = new CreateCategoryCommand("Mobile");
            var result = await handler.Handle(command, CancellationToken.None);



            //assert


            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            var category = repo.GetById(result.Id);
            category.Should().NotBeNull();
            category?.Name.Should().Be(command.name);
        }




        [Fact]
        public async Task Handle_Should_Update_Category()
        {
            // arrange

            string dbName = Guid.NewGuid().ToString();
            var repo = new CategoryRepositories(_fixture.BuildDbContext(dbName));

            var category = Category.Create("لوازم خانگی");
            var categoryid = repo.Create(category);
            var Command = new UpdateCategoryCommand(categoryid,"لوازم الکتریکی");

            var handler = new UpdateCategoryCommandHandle(repo);

            // act
            var result = await handler.Handle(Command, CancellationToken.None);

            // assert

            category.Id.Should().BeGreaterThan(0);
            category.Name.Should().NotBe("لوازم خانگی");
            category.Name.Should().Be("لوازم الکتریکی");

        }



        [Fact]
        public async Task Handle_Should_Delete_Category()
        {


            // arrange
            string dbName = Guid.NewGuid().ToString();
            var repo = new CategoryRepositories(_fixture.BuildDbContext(dbName));

            var category = Category.Create("لوازم خانگی");
            var categoryid = repo.Create(category);
            var Command = new DeleteCategoryCommand(categoryid);

           // var handler = new DeleteCategoryCommandHandler(repo);

            // act
          //  var result = await handler.Handle(Command, CancellationToken.None);

            
           

            // assert
            var deletedUser = repo.GetById(categoryid);
            deletedUser.Should().BeNull();

        }



    }
}

