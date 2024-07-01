using Domain.Base;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Products
{
    public class Product : BaseEntity<int>
    {
       

        public string SKU { get; set; }
        public string Title { get; set; }

        public string Picter { get; set; }

        //
        public virtual int CategoyId { get; set; }


    }
}


