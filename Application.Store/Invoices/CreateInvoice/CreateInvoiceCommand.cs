using MediatR;

namespace Application.Invoices.CreateInvoice
{
    public record CreateInvoiceCommand(string InvoiceNo, int addressId, decimal discount) : IRequest<CreateInvoiceCommandResponse>;

}
