using Domain.Invoices;

namespace Application.Carts.GetCart
{
    public record GetCartQueryResponse(int Id, decimal SalePrice)
    {
        public static explicit operator GetCartQueryResponse(CartOrInvoiceDtail cart)
        {

            return new GetCartQueryResponse(cart.Id, cart.SalePrice);
        }

    }




}
