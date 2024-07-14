using Application.Users.Create;
using Application.Users.Get;
using Application.Users.GetAll;
using Domain.Products;
using Domain.Users;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.UsersTest
{
    public class GetUserHandlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetUserHandlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]

        public async Task Handle_Should_Get_User()
        {
            //arenge 
            string dbName = Guid.NewGuid().ToString();


            var repo = new UserRepositories(_fixture.BuildDbContext(dbName));

            var user = User.Create("name", "family", "phone", "Email");


           int UserId = repo.Create(user);

            var quary = new GetUserQuery(UserId);

            var handel = new GetUserQueryHamdler(repo);

            //act
          
         
            var result = await handel.Handle(quary, CancellationToken.None);

            //assert


            result.Should().NotBeNull();

            result.Id.Should().Be(UserId);

            result.name.Should().Be(result.name);

        }

    }
}
