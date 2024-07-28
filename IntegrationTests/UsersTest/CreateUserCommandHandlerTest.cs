<<<<<<< HEAD
﻿using Application.Products.CreateProduct;
using Application.Users.Create;
=======
﻿using Application.Users.Create;
>>>>>>> 44e8d510752a5fe65995df9ef60ead7656586189
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
            var command = new CreateUserCommand("ali", "ali", "1", "A@a.com");
            var result = await handel.Handle(command, CancellationToken.None);

            //assert


            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            var user = repo.GetById(result.Id);
            user.Should().NotBeNull();
            user?.Name.Should().Be(command.name);
        }


        [Fact]
        public async Task Handle_Should_Update_User()
        {
<<<<<<< HEAD
            // arrange

=======
            //arrange
>>>>>>> 44e8d510752a5fe65995df9ef60ead7656586189
            string dbName = Guid.NewGuid().ToString();
            var dbContext = _fixture.BuildDbContext(dbName);
            var repo = new UserRepositories(dbContext);

<<<<<<< HEAD
            var user = User.Create("ali", "aliF", "1", "A@a.com");
            var userId = repo.Create(user);

            var Command = new UpdateUserCommand(userId, "Mamad", "MamadZade");

            var handler = new UpdateUserCommandHandler(repo);

            // act
            await handler.Handle(Command, CancellationToken.None);

            // assert

            user.Id.Should().BeGreaterThan(0);
            user.Name.Should().NotBe("ali");
            user.Name.Should().Be("Mamad");
=======

            var user = User.Create("ali", "ali", "1", "A@a.com");
            repo.Create(user);

            var command = new UpdateUserCommand(user.Id, "Mamad", "Mamad", "123", "john.com");
            var handler = new UpdateUserCommandHandler(repo);

            // act
            var result = await handler.Handle(command, CancellationToken.None);

            // assert
            result.Should().NotBeNull();
            result.id.Should().Be(user.Id);


            var updatedUser = repo.GetById(user.Id);
            updatedUser.Should().NotBeNull();
            updatedUser.Name.Should().Be("John");
>>>>>>> 44e8d510752a5fe65995df9ef60ead7656586189

        }




        [Fact]
        public async Task Handle_Should_Delete_User()
        {
<<<<<<< HEAD
           

            // arrange
            string dbName = Guid.NewGuid().ToString(); 
            var dbContext = _fixture.BuildDbContext(dbName); 
            var repo = new UserRepositories(dbContext); 

            var user = User.Create("ali", "aliF", "1", "A@a.com");
            var userId = repo.Create(user);

            var command = new DeleteUserCommand(userId);
            var handler = new DeleteUserCommandHandler(repo);

            // act
            await handler.Handle(command, CancellationToken.None);
=======
            string dbName = Guid.NewGuid().ToString();
            var dbContext = _fixture.BuildDbContext(dbName);
            var repo = new UserRepositories(dbContext);


            var user = User.Create("ali", "ali", "1", "A@a.com");
            repo.Create(user);

            var command = new DeleteUserCommand(user.Id);
            var handler = new DeleteUserCommandHandler(repo);


            var result = await handler.Handle(command, CancellationToken.None);


            result.Should().NotBeNull();
            result.Id.Should().Be(user.Id);


            var deletedUser = repo.GetById(user.Id);
            deletedUser.Should().BeNull();

>>>>>>> 44e8d510752a5fe65995df9ef60ead7656586189

            // assert
            var deletedUser = repo.GetById(userId);
            deletedUser.Should().BeNull(); 

        }
<<<<<<< HEAD

    
       

    }
}
=======
>>>>>>> 44e8d510752a5fe65995df9ef60ead7656586189

    }
}