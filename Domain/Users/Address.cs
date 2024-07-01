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
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
