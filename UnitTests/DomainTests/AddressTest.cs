using Domain.Users;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DomainTests
{
    public class AddressTest
    {
        [Fact]
        public void created_object_should_return_value()
        {
            string City = "Urmia";
            string State = "West Azarbajan";
            string PostalCode = "15388645";



            Address addres = Address.Create(City, State, PostalCode);


            addres.Should().NotBeNull();
            addres.City.Should().Be(City);
            addres.PostalCode.Should().Be(PostalCode);
            addres.State.Should().Be(State);



        }
    }
}
