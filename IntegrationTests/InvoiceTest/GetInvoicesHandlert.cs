using Application.Categorys.GetCatrgorys;
using Application.Invoices.Get;
using Application.Invoices.GetInvoices;
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
using GetInvoiceHandler = Application.Invoices.GetInvoices.GetInvoiceHandler;

namespace IntegrationTests.InvoiceTest
{
    public class GetInvoicesHandlertTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;
        public GetInvoicesHandlertTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_Should_Get_Sum_Invoicese()
        {
            // arreng
            var dbName = Guid.NewGuid().ToString();
            var repo = new InvoiceRepositories(_fixture.BuildDbContext(dbName));


            var invoice1 = Invoice.Create("100",1,1);
            var invoice2= Invoice.Create("101",1,1);
            var invoice3 = Invoice.Create("102",1,1);

            repo.Create(invoice1);
            repo.Create(invoice2);
            repo.Create(invoice3);

            var query = new GetInvoicesSQuery(1, 10);
            var handler = new GetInvoiceHandler(repo);

            // act
            var result = await handler.Handle(query, CancellationToken.None);

            // assert

            result.Should().NotBeNull();

            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            result.First().id.Should().Be(invoice1.Id);
            result.First().InvoceNon.Should().Be(invoice1.InvoiceNo);
            
            result.SingleOrDefault(p=>p.id==2).id.Should().Be(invoice2.Id);
            result.SingleOrDefault(p => p.id == 2).InvoceNon.Should().Be(invoice2.InvoiceNo);
            
            result.SingleOrDefault(p => p.id == 3).id.Should().Be(invoice3.Id);
            result.Last().InvoceNon.Should().Be(invoice3.InvoiceNo);

        }
    }

}
