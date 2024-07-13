using Application.Invoices.Get;
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

namespace IntegrationTests.InvoiceTest
{
    public class GetInvoiceHandlerTest
    {
        private readonly DbContextFixture _fixture;
        public GetInvoiceHandlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        public async Task Handle_Should_Get_Invoce()
        {
            //arrenge
            var dbName = Guid.NewGuid().ToString();

            var repo = new InvoiceRepositories(_fixture.BuildDbContext(dbName));


            var invoce = Invoice.Create("15995175", 12, 50.68m);

            var invoiceId = repo.Create(invoce);

            var query = new GetInvoiceQuery(invoiceId);
            var Handle = new GetInvoiceHandler(repo);
            //act

            var result = await Handle.Handle(query, CancellationToken.None);

            //assert

            result.Should().NotBeNull();
            result.Id.Should().Be(invoiceId);
            result.InvoiceNo.Should().Be(result.InvoiceNo);

        }


    }
}
