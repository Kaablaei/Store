using Application.Invoices.GetInvoices;
using Application.Users.GetAll;
using Domain.Invoices;
using Domain.Users;
using Domain.Users.Repository;
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
    public class GetUserSHandelerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetUserSHandelerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]

        public async Task Handle_Should_Ger_Sum_Users()
        {
            // arreng1
            var dbName = Guid.NewGuid().ToString();

            var repo = new UserRepositories(_fixture.BuildDbContext(dbName));
          
            var user1 = User.Create("name1", "family1", "phone1", "Email1");
            var user2 = User.Create("name2", "family2", "phone2", "Email2");
            var user3 = User.Create("name3", "family3", "phone3", "Email3");

           
            repo.Create(user1);
            repo.Create(user2);
            repo.Create(user3);

            var query = new GetUsersQuery(1, 10);
            var handler = new GetUserSHandler(repo);
            //act 

            var result = await handler.Handle(query, CancellationToken.None);

            //assert

            result.Should().NotBeNull();

            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            result.First().Id.Should().Be(user1.Id);
            result.First().name.Should().Be(user1.Name);

            result.SingleOrDefault(p => p.Id == 2).Id.Should().Be(user2.Id);
            result.SingleOrDefault(p => p.Id == 2).name.Should().Be(user2.Name);

            result.SingleOrDefault(p => p.Id == 3).Id.Should().Be(user3.Id);
            result.Last().name.Should().Be(user3.Name);
        }
    }
}
