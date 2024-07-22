using Application.Carts.GetCart;
using Application.Carts.GetCarts;
using Domain.Invoices;
using Domain.Products;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.CartOrInvoiceDetail
{
    public class GetCartSQuaryHandlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetCartSQuaryHandlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public async Task Handle_Should_Get_CartS()
        {
            //arrage
            var dbName = Guid.NewGuid().ToString();
            var repo = new CartRepository(_fixture.BuildDbContext(dbName));

            var cart = CartOrInvoiceDtail.Create(1,1, 1.1m, 1.1m ,1);
            var cart2 = CartOrInvoiceDtail.Create(2,2, 2.2m, 2.2m,1);
            var cart3 = CartOrInvoiceDtail.Create(3,3, 3.3m, 3.3m,1);

            repo.Create(cart);
            repo.Create(cart2);
            repo.Create(cart3);
            var query = new GetCartSQuery(1, 10);
            var handler = new GetCartSHandler(repo);
            //act

            var result = await handler.Handle(query, CancellationToken.None);

            //assert

            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            result.First().id.Should().Be(cart.Id);
            result.First().sealprice.Should().Be(cart.SalePrice);

            result.Skip(1).First().id.Should().Be(cart2.Id);
            result.Skip(1).First().sealprice.Should().Be(cart2.SalePrice);

            result.Last().id.Should().Be(cart3.Id);
            result.Last().sealprice.Should().Be(cart3.SalePrice);
        }
    }
}
