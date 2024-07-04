
using Domain.Users;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DomainTests
{
    public class UserAddressTest
    {

        [Fact]
        public void created_object_should_return_value()
        {
            
            int Userid =10;
            int Addressid = 153;


          var Address = UseAddress.Create(Userid, Addressid);


            Address.Should().NotBeNull();
            Address.UserId.Should().Be(Userid);
            Address.AddresId.Should().Be(Addressid);

        }

    }
}
