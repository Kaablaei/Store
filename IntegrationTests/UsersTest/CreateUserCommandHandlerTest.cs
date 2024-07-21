using Application.Users.Create;
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
            // Arrange

            string dbName = Guid.NewGuid().ToString();
            var repo = new UserRepositories(_fixture.BuildDbContext(dbName));

            var user = User.Create("ali", "ali", "1", "A@a.com");

            var Command = new UpdateUserCommand(user.Id, "John", "Mamad", "123", "john.com");



            var handler = new UpdateUserCommandHandler(repo);

            // act
            var result = await handler.Handle(Command, CancellationToken.None);

            // assert
           
            user.Id.Should().BeGreaterThan(0);
            user.Name.Should().NotBe("ali");
            user.Name.Should().Be("John");

        }



        [Fact]
        public async Task Handle_Should_Delete_User()
        {

            string dbName = Guid.NewGuid().ToString();

            var repo = new UserRepositories(_fixture.BuildDbContext(dbName));

            var handel = new CrateUserCommandHandler(repo);
            //act
            var command = new CreateUserCommand("ali", "ali", "1", "A@a.com");

            var result = await handel.Handle(command, CancellationToken.None);


        }
    }
}

