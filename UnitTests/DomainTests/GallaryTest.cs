using Domain.Products;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DomainTests
{
    public class GallaryTest
    {
        [Fact]
        public void created_object_should_return_value()
        {
            //arreng & Act

            var gallery = Gallary.Create(12, "image");

            //assert
            gallery.Should().NotBeNull();
            gallery.ProductId.Should().Be(12);
            gallery.Image.Should().NotBeNull();
            gallery.Image.Should().Be("image");



        }
    }
}
