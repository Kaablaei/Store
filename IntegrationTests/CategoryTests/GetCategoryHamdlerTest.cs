using Application.Categorys.GetCatrgory;
using Domain.Products;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;

namespace IntegrationTests.CategoryTests
{
    public class GetCategoryHamdlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetCategoryHamdlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_Should_Get_Category()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repo = new CategoryRepositories(_fixture.BuildDbContext(dbName));


            var category = Category.Create("Sample");

            var categoryId = repo.Create(category);

            var query = new GetCategoryQuery(categoryId);

            var handler = new GetCategoryHamdler(repo);
            //act

            var result = await handler.Handle(query, CancellationToken.None);


            //assert


            result.Should().NotBeNull();
            result.Id.Should().Be(categoryId);
            result.Name.Should().Be(result.Name);

        }
    }
}

