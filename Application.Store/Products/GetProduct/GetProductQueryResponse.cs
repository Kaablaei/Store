using Application.Products.GetProducts;
using Domain.Products;

namespace Application.Products.GetProduct
{
    public record GetProductQueryResponse(int Id ,string title)
    {
        public static explicit operator GetProductQueryResponse(Product product)

        {

            return new GetProductQueryResponse(product.Id ,product.Title);
        }
    }
}
