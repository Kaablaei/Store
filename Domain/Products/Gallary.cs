using Domain.Base;

namespace Domain.Products
{
    public class Gallary : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public Product product { get; set; }
        public string Image { get; set; }

        public static Gallary Create(int productid, string image)
        {
            return new Gallary
            {
                ProductId = productid,
                Image = image
            };
        }
    }
}


