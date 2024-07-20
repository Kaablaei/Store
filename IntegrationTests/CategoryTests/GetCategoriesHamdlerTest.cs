using Application.Categorys.GetCatrgory;
using Application.Categorys.GetCatrgorys;
using Domain.Products;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.CategoryTests
{
    public class GetCategoriesHamdlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetCategoriesHamdlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_Should_Get_Categorese()
        {
            // arreng
            var dbName = Guid.NewGuid().ToString();
            var repo = new CategoryRepositories(_fixture.BuildDbContext(dbName));

           
            var category1 = Category.Create("Sample1");
            var category2 = Category.Create("Sample2");
            var category3 = Category.Create("Sample3");

            repo.Create(category1);
            repo.Create(category2);
            repo.Create(category3);

            var query = new GetCategoriesQuery(1, 10); 
            var handler = new GetCategoriesQueryHandler(repo);

            // act
            var result = await handler.Handle(query, CancellationToken.None);

            // assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            result.First().Id.Should().Be(category1.Id);
            result.First().name.Should().Be(category1.Name);

            result.Skip(1).First().Id.Should().Be(category2.Id);
            result.Skip(1).First().name.Should().Be(category2.Name);

            result.Last().Id.Should().Be(category3.Id);
            result.Last().name.Should().Be(category3.Name);
        }
    }

}

