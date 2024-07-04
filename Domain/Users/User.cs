using Domain.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            return new User
            {
                Name = name,
                Family = family,
                Phone = phone,
                Email = email,
                
            };

        }


    }


}
