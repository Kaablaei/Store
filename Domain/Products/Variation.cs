using Domain.Base;
using Domain.Invoices;

namespace Domain.Products
{
    public class Variation : BaseEntity<int>
    {


        public int ProductId { get; set; }

        public Product product { get; set; }

        public string Color { get; set; }
        public string Size { get; set; }


        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }

        public int InvoceId { get; set; }
        public Invoice invoice { get; set; }


        //
        public static Variation Create(int progetctid, string color, string size, decimal price,
            decimal saleproce, int invoiceid)
        {
            return new Variation
            {
                ProductId = progetctid,
                Color = color,
                Size = size,
                Price = price,
                SalePrice = saleproce,
                InvoceId = invoiceid
            };
        }

    }
}