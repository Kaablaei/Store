using Domain.Products;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DomainTests
{
    public class CommentsTest
    {
        [Fact]
        public void created_object_should_return_value()
        {
            //Arrang & Act
            var comment = Comments.Create(1,  "Hi");


            //assert

            comment.Should().NotBeNull();
            comment.ProductId.Should().Be(1);
            comment.Content.Should().Be("Hi");
            

        }

    }
}
