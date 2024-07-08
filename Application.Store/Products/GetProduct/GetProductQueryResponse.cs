using Application.Products.GetProducts;
using Domain.Products;

namespace Application.Products.GetProduct
{
    public record GetProductQueryResponse(int Id)
    {
        public static explicit operator GetProductQueryResponse(Product product)

        {

            return new GetProductQueryResponse(product.Id);
        }
    }
}
