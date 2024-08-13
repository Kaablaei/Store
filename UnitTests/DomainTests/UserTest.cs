
using Domain.Users;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnitTests.DomainTests
{
    public class UserTest
    {

        [Fact]
        public void created_object_should_return_value()
        {
            //arrange
            string name = "Ali";
            string phone = "0914444444";

            string family = "Alii";

            string email = "Ali@A.com";

            //act 

            var user = User.Create(name, family, phone, email ," ");


            //assert

            user.Should().NotBeNull();
            user.Email.Should().Be(email);
            user.Family.Should().Be(family);
            user.UserName.Should().Be(name);
            
            
        }


    }
}
