using Domain.Products;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DomainTests
{
    public class CategoryTest
    {
        [Fact]
        public void created_object_should_return_value()
        {
            //Arrginr & act

            Category category = Category.Create("name");

            //assert
            category.Should().NotBeNull();  
            category.Name.Should().Be("name");

        }
    }
}
