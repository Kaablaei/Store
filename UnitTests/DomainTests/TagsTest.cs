using Domain.Products;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DomainTests
{
    public class TagsTest
    {
        [Fact]
        public void created_object_should_return_value()
        {
            //areng
            string content = "لوازم آرایش";
            int productId = 1;

            //act
            var tag = Tags.Create(content, productId);

            //asets
            tag.TagContent.Should().Be(content);
            tag.ProductId.Should().Be(productId);
           

        }
    }
}
