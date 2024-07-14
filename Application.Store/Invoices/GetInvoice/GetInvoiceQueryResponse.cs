using Domain.Invoices;

namespace Application.Invoices.Get
{
    public record GetInvoiceQueryResponse(int Id , string InvoiceNo)
    {
        public static explicit operator GetInvoiceQueryResponse(Invoice invoice)

        {

            return new GetInvoiceQueryResponse(invoice.Id,invoice.InvoiceNo);
        }


    }

}
