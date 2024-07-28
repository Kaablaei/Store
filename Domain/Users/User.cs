using Ardalis.GuardClauses;
using Domain.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class User : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public static User Create(string name, string family, string phone, string email)
        {

            name = Guard.Against.NullOrWhiteSpace(name);
            family = Guard.Against.NullOrEmpty(family);
            phone = Guard.Against.NullOrEmpty(phone);
            email = Guard.Against.NullOrEmpty(email);

            return new User
            {

                CreateOn = DateTime.UtcNow,
                CratetdAgent = "",
                CreatedIP = "",
                ModifyAgent = "",
                ModifyIP = "",
                Version = 1,
                Name = name,
                Family = family,
                Phone = phone,
                Email = email,
                
            };
        }


        public  void Update(string name, string family)
        {
            Name = name;
            Family = family;
        }
    }
}
