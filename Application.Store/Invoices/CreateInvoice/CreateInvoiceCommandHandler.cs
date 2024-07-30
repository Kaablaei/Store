using MediatR;
using Domain.Invoices.Repository;
using Domain.Invoices;

namespace Application.Invoices.CreateInvoice
{
    public class CreateInvoiceCommandHandler(IInvoiveRepository repository) : IRequestHandler<CreateInvoiceCommand, CreateInvoiceCommandResponse>
    {
        public async Task<CreateInvoiceCommandResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoce = Invoice.Create(request.InvoiceNo ,request.addressId,request.discount);
            var id = repository.Create(invoce);


            return new CreateInvoiceCommandResponse(id);
        }
    }

}
