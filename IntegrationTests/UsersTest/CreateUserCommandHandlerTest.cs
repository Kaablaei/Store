using Application.Products.CreateProduct;
using Application.Users.Create;

﻿using Application.Users.Create;

using Application.Users.DeleteUser;
using Application.Users.UpdateUser;
using Domain.Users;
using Domain.Users.Repository;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using System;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IntegrationTests.Users
{
    public class CreateUserCommandHandlerTest : IClassFixture<DbContextFixture>
    {

        private readonly DbContextFixture _fixture;

        public CreateUserCommandHandlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task Handle_Should_Create_User()
        {

            //arrange
            string dbName = Guid.NewGuid().ToString();

            var repo = new UserRepositories(_fixture.BuildDbContext(dbName));

            var handel = new CrateUserCommandHandler(repo);
            //act
            var command = new CreateUserCommand("ali", "ali", "1", "A@a.com","");
            var result = await handel.Handle(command, CancellationToken.None);

            //assert


            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            var user = repo.GetById(result.Id);
            user.Should().NotBeNull();
            user?.UserName.Should().Be(command.name);
        }


        [Fact]
        public async Task Handle_Should_Update_User()
        {

            string dbName = Guid.NewGuid().ToString();
            var dbContext = _fixture.BuildDbContext(dbName);
            var repo = new UserRepositories(dbContext);


            var user = User.Create("ali", "aliF", "1", "A@a.com" ," ");
            var userId = repo.Create(user);

            var Command = new UpdateUserCommand(userId, "Mamad", "MamadZade");

            var handler = new UpdateUserCommandHandler(repo);

            // act
            await handler.Handle(Command, CancellationToken.None);

            // assert

            user.Id.Should().BeGreaterThan(0);
            user.UserName.Should().NotBe("ali");
            user.UserName.Should().Be("Mamad");

          

            // act
        

            // assert
           

            var updatedUser = repo.GetById(user.Id);
            updatedUser.Should().NotBeNull();
            updatedUser.UserName.Should().Be("John");

        }




        [Fact]
        public async Task Handle_Should_Delete_User()
        {

           

            // arrange
            string dbName = Guid.NewGuid().ToString(); 
            var dbContext = _fixture.BuildDbContext(dbName); 
            var repo = new UserRepositories(dbContext); 

            var user = User.Create("ali", "aliF", "1", "A@a.com" , " ");
            var userId = repo.Create(user);

            var command = new DeleteUserCommand(userId);
            var handler = new DeleteUserCommandHandler(repo);

            // act
            await handler.Handle(command, CancellationToken.None);
           

            var result = await handler.Handle(command, CancellationToken.None);


            result.Should().NotBeNull();
            result.Id.Should().Be(user.Id);


            var deletedUser = repo.GetById(user.Id);
            deletedUser.Should().BeNull();



            // assert
           
            deletedUser.Should().BeNull(); 

        }    
       

    }
}


