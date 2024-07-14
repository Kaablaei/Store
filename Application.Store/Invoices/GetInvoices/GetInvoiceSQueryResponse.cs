using Domain.Invoices;

namespace Application.Invoices.GetInvoices
{
    public record GetInvoiceSQueryResponse( string InvoceNon, int id ,decimal Price)
    {
        public static explicit operator GetInvoiceSQueryResponse(Invoice invoice)

        {

            return new GetInvoiceSQueryResponse( invoice.InvoiceNo, invoice.Id, invoice.TotalPrice);
        }
    }

}
