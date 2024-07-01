using Domain.Base;

namespace Domain.Products
{
    public class Variation : BaseEntity<int>
    {
      

        public int ProgetctId { get; set; }

        public string Color { get; set; }
        public string Size { get; set; }


        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }

        public int InvoceId { get; set; }

    }
}