using Ardalis.GuardClauses;
using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Products
{
    public class Category : BaseEntity<int>
    {

        public string Name { get; set; }

        public void Update(string Name)
        {
            this.Name = Name;
        }

        public static Category Create(string name)
        {
            name = Guard.Against.NullOrEmpty(name);
            return new Category
            {
                Name = name,
                CreateOn = DateTime.UtcNow,
                CratetdAgent="",
                CreatedIP= "",
                ModifyAgent= "",
                ModifyIP= ""

            };
        }
    }

   


}
