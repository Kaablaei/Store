using Domain.Base;

namespace Domain.Products
{
    public class Comments : BaseEntity<int>
    {
       

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public string IP { get; set; }

    }
}
