using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.GetProducts
{
    public record GetProductsQueryResponse(int Id, string Title)
    {
        public static explicit operator GetProductsQueryResponse(Product product)
        
        {

            return new GetProductsQueryResponse (product.Id, product.Title);
        }
    }
}
