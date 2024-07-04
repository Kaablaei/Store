using Domain.Base;

namespace Domain.Products
{
    public class Tags : BaseEntity<int>
    {


        public string TagContent { get; set; }

        //
        public int ProductId { get; set; }
        public Product Product { get; set; }


        //
        public static Tags Create(string tagcontent, int productid)
        {
            return new Tags
            {
                TagContent = tagcontent,
                ProductId = productid
            };

        }

    }
}


