using Ardalis.GuardClauses;
using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Category : BaseEntity<int>
    {

        public string Name { get; set; }


        public static Category Create(string name)
        {
            name = Guard.Against.NullOrEmpty(name);
            return new Category
            {
                Name = name,
                CreateOn = DateTime.UtcNow
            };
        }
    }

    //public class Sample
    //{
    //    public Sample()
    //    {
    //        var t =  Category.Create("2");
    //    }
    //}



}
