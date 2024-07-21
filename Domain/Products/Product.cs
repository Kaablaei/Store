using Ardalis.GuardClauses;
using Domain.Base;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Products
{
    public class Product : BaseEntity<int>
    {
        public string SKU { get; set; }
        public string Title { get; set; }
        public decimal Picter { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public static Product Create(string sku, string title, decimal price, int categoryid)
        {
            sku = Guard.Against.NullOrEmpty(sku);
            title = Guard.Against.NullOrEmpty(title);
            price = Guard.Against.NegativeOrZero(price);
            return new Product
            {

                CreateOn = DateTime.UtcNow,
                CratetdAgent = "",
                CreatedIP = "",
                ModifyAgent = "",
                ModifyIP = "",
                SKU = sku,
                Title = title,
                Picter = price,
                CategoryId = categoryid

            };
        }
        public void Update(string sku, string title, decimal price, int categoryid)
        {
            SKU = sku;
            Title = title;
            Picter = price;
            CategoryId = categoryid;
        }
    }
}


