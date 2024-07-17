
using Domain.Invoices;

namespace Application.Carts.GetCarts
{
    public record GetCartSQueryResponse(int id, decimal sealprice)
    {
        public static explicit operator GetCartSQueryResponse(CartOrInvoiceDtail cart)
        {

            return new GetCartSQueryResponse(cart.Id, cart.SalePrice);
        }

    }

}
