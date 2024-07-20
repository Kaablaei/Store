using Application.Categorys.GetCatrgorys;
using Application.Products.GetProducts;
using Domain.Products;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.ProductTest
{
    public class GetProductSQueryHandlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetProductSQueryHandlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public async Task Handle_Should_Get_Products()
        {
            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repo = new ProductRepositories(_fixture.BuildDbContext(dbName));


            var product = Product.Create("1", "1", 1.1m, 1);
            var product2 = Product.Create("2", "2", 2.2m, 2);
            var product3 = Product.Create("3", "3", 3.3m, 3);

            repo.Create(product);
            repo.Create(product2);
            repo.Create(product3);
            var query = new GetProductsQuery(1, 10);
            var handler = new GetProductsQueryHandler(repo);
            //act

            var result = await handler.Handle(query, CancellationToken.None);

            //assert

            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            result.First().Id.Should().Be(product.Id);
            result.First().Title.Should().Be(product.Title);

            result.Skip(1).First().Title.Should().Be(product2.Title);
            result.Skip(1).First().Title.Should().Be(product2.Title);

            result.Last().Title.Should().Be(product3.Title);
            result.Last().Title.Should().Be(product3.Title);
        }

    }
}
