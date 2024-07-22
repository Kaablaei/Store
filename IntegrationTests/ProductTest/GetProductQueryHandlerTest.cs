using Application.Invoices.Get;
using Application.Products.CreateProduct;
using Application.Products.GetProduct;
using Domain.Invoices;
using Domain.Products;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.ProductTest
{
    public class GetProductQueryHandlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;



        public GetProductQueryHandlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_Should_Get_Product()
        {
            //arenge
            string dbName = Guid.NewGuid().ToString();
            
            var repo = new ProductRepositories(_fixture.BuildDbContext(dbName));
            var product = Product.Create("2", "2", 12);
            var productId = repo.Create(product);

            var query = new GetProductQuery(productId);

            var handel = new GetProductQueryHandler(repo);

            //act
            var result = await handel.Handle(query, CancellationToken.None);
            //assert
            result.Should().NotBeNull();
            result.Id.Should().Be(productId);
            result.title.Should().Be(product.Title);

        }

    }
}
