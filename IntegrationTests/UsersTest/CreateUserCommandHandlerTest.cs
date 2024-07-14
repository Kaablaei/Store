using Application.Users.Create;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var handel = new CreateUserCommandHandler(repo);
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

    }
}

