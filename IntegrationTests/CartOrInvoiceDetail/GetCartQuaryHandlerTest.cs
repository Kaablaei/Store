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
    public class GetCartQuaryHandlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        public GetCartQuaryHandlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_Should_Get_Cart()
        {
            var dbName = Guid.NewGuid().ToString();
            var repo = new CartRepository(_fixture.BuildDbContext(dbName));

            var cart = CartOrInvoiceDtail.Create(1, 1, 1.1m, 1.1m);
        

           var cartid= repo.Create(cart);
            
            var query = new GetCartQuer(cartid);
            var handel = new GetCartQuerHandler(repo);

            //act
            var result = await handel.Handle(query, CancellationToken.None);

            //assert
            result.Should().NotBeNull();
            result.Id.Should().Be(cartid);
            result.SalePrice.Should().Be(cart.SalePrice);

        }
    }

}
