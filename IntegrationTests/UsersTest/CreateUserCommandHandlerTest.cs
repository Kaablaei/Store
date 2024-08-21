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
            // arrange
            string dbName = Guid.NewGuid().ToString();
            var dbContext = _fixture.BuildDbContext(dbName);
            var repo = new UserRepositories(dbContext);

            var user = User.Create("ali", "aliF", "1", "A@a.com");
            var userId = repo.Create(user);

            var command = new UpdateUserCommand(userId, "Mamad", "MamadZade");
            var handler = new UpdateUserCommandHandler(repo);

            // act
            await handler.Handle(command, CancellationToken.None);

            // assert
            var updatedUser = repo.GetById(userId);
            updatedUser.Should().NotBeNull();
            updatedUser.UserName.Should().Be("Mamad");
            updatedUser.Family.Should().Be("MamadZade");
        }



        [Fact]
        public async Task Handle_Should_Delete_User()
        {
            //arange 
            string dbName = Guid.NewGuid().ToString();
            var dbContext = _fixture.BuildDbContext(dbName);
            var repo = new UserRepositories(dbContext);

            var user = User.Create("ali", "aliF", "1", "A@a.com");
            var userId = repo.Create(user);

            var command = new DeleteUserCommand(userId);
            var handler = new DeleteUserCommandHandler(repo);

            // act
            var result = await handler.Handle(command, CancellationToken.None);

            // assert
            result.Should().NotBeNull();
            result.Id.Should().Be(userId);

            var deletedUser = repo.GetById(userId);
            deletedUser.Should().BeNull();

        }    
       

    }
}


