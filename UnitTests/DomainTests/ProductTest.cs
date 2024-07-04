using Domain.Products;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DomainTests
{
    public class ProductTest
    {
        [Fact]
        public void created_object_should_return_value()
        {
            //areng
            string sku = "TS FM 56";
            string title = "Title";

            //act
            var product = Product.Create(sku,title,20M,1);

            //assets

            product.Should().NotBeNull();
            product.SKU.Should().Be(sku);
            product.Title.Should().Be(title);
            product.Picter.Should().Be(20M);
            product.CategoryId.Should().Be(1);
        }
    }
}
