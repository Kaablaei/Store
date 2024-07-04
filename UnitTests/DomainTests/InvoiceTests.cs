using Domain.Invoices;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DomainTests
{
    public class InvoiceTests
    {
        [Fact]
        public void created_object_should_return_value()
        {


            //arrange
            var addressId = 1;
            var discount = 200;
            //act         
            var invoice = Invoice.Create(addressId, discount);


            //assert

            invoice.Should().NotBeNull();
            invoice.AdressId.Should().Be(addressId);
            invoice.Discount.Should().Be(discount);
            invoice.Statuse.Should().Be(Domain.InvoiceStatus.Pending);

        }

        [Fact]
        public void payed_invoic_should_change_status()
        {
            //arrange
            var addressId = 1;
            var discount = 200;
            var invoice = Invoice.Create(addressId, discount);

            //act         

            invoice.Payed();

            //assert
            invoice.Statuse.Should().Be(Domain.InvoiceStatus.Payed);
            invoice.ModifiedOn.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));



        }
    }
}
