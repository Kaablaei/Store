using Ardalis.GuardClauses;
using Domain.Base;
using System.Diagnostics;

namespace Domain.Products
{
    public class Comments : BaseEntity<int>
    {


        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Content { get; set; }

        public static Comments Create(int productId,  string content)
        {
            content = Guard.Against.NullOrEmpty(content);
            return new Comments
            {
                ProductId = productId,
  
                Content = content,
               
                //NOT IP
            };
        }
    }
}
