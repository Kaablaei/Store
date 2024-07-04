using Domain.Base;

namespace Domain.Products
{
    public class Comments : BaseEntity<int>
    {


        public int ProductId { get; set; }
        public Product Product { get; set; }
     

        public string Content { get; set; }

        

     




        //
        public static Comments Create(int productId,  string content)
        {
            return new Comments
            {
                ProductId = productId,
              
              
                Content = content,
               
                //NOT IP
            };
        }
    }
}
