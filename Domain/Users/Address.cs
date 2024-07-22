using Ardalis.GuardClauses;
using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class Address : BaseEntity<int>
    {

        public User User { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public void Update(string city, string state, string postalcode)
        {
            City = city;
            State = state;
            PostalCode = postalcode;
        }

        public static Address Create(string city, string state, string postcart)
        {
            city = Guard.Against.NullOrEmpty(city);
            state = Guard.Against.NullOrEmpty(state);
            postcart = Guard.Against.NullOrEmpty(postcart);

            return new Address
            {
                City = city,
                State = state,
                PostalCode = postcart
            };
        }

    }
}
