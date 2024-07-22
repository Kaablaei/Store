using Domain.Invoices;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DomainTests
{
    public class CartOrInvoiceDtailTest
    {

        [Fact]
        public void created_object_should_return_value()
        {
            //arginr
            int userid = 1;
            int valiuatoin = 1;
            decimal price = 12.56m;
            decimal saleprice = 12.56m;

            //act
            var ci = CartOrInvoiceDtail.Create(userid, valiuatoin, price, saleprice,1);
            //assert

            ci.Should().NotBeNull();
            ci.VaridationId.Should().Be(valiuatoin);
            ci.UserId.Should().Be(userid);
            ci.Price.Should().Be(price);
            ci.SalePrice.Should().Be(saleprice);


        }
    }
}
