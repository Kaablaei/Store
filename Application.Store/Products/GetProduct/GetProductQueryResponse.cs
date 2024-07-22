using Application.Products.GetProducts;
using Domain.Products;
using System.ComponentModel;

namespace Application.Products.GetProduct
{
    public record GetProductQueryResponse(int Id ,string title,string suk)
    {
        public static explicit operator GetProductQueryResponse(Product product)
        {
            return new GetProductQueryResponse(product.Id ,product.Title,product.SKU);
        }
    }
}
