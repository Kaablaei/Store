using Application.Categorys.CreateCategory;
using Application.Invoices.CreateInvoice;
using Domain.Products;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.InvoiceTest
{
    public class CreatInvoiceCommendHandlerTest: IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        public CreatInvoiceCommendHandlerTest(DbContextFixture fixture)
        {
            _fixture = fixture; 
        }


        [Fact]
        public async Task Handler_Should_Create_Invoices()
        {
            //argine
            string dbName = Guid.NewGuid().ToString();

            var repo = new InvoiceRepositories(_fixture.BuildDbContext(dbName));

            var handler = new CreateInvoiceCommandHandler(repo);

            //act
            var command = new CreateInvoiceCommand("1586945210",12, 20.50M);
            var result = await handler.Handle(command, CancellationToken.None);
            //assert

            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            var invoce = repo.GetById(result.Id);
            invoce.Should().NotBeNull();
            invoce.InvoiceNo.Should().Be(command.InvoiceNo);
        }
    }
}
