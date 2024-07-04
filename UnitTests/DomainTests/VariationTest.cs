using Domain.Products;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DomainTests
{
    public class VariationTest
    {
        [Theory]
        [InlineData(null,null)]
        [InlineData("red",null)]
        [InlineData(null,"XL")]
        public void created_object_should_return_value(string color, string size)
        {


           var variatin = Variation.Create(12, color, size, 20.50M, 20.50M, 15);

           variatin.Should().NotBeNull();

            variatin.Color.Should().Be(color);
            variatin.ProductId.Should().Be(12);
            //variatin.Size.Should().Be("12");
            //variatin.Size.Should
            variatin.SalePrice.Should().Be(20.50M);
            variatin.Price.Should().Be(20.50M);
            variatin.InvoceId.Should().Be(15);
            

        }


    }
}
