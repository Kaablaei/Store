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
    public class GetCategorySHamdlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetCategorySHamdlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        public async Task Handle_Should_Get_Sum_Categorese()
        {
            // Arrange
            var categoryName = "SampleCategory";
            var dbContextName = Guid.NewGuid().ToString();
            var dbContext = _fixture.BuildDbContext(dbContextName);
            var repo = new CategoryRepositories(dbContext);

            List<Category> categories = new List<Category>();
            List<int> categoryIds = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                var category = Category.Create($"{categoryName}{i + 1}");
                categories.Add(category);
                categoryIds.Add(category.Id);
            }

            await dbContext.Categorys.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            var query = new GetCategorysQuery(PageNo: 1, PageSize: 10);
            var handler = new GetCategoryQueryHandler(repo);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(10);
            result.First().name.Should().Be($"{categoryName}1");
            result.Last().name.Should().Be($"{categoryName}10");

        }

    }
}
