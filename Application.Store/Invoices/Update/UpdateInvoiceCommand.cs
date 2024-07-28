using Domain;
using Domain.Invoices.Repository;
using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Update
{
    public record UpdateInvoiceCommand(int Id, InvoiceStatus status, string TrakingCode) : IRequest<UpdateInvoiceCommandResponse>;

    public record UpdateInvoiceCommandResponse(int Id);

    public class UpdateInvoiceCommandHandler(IInvoiveRepository repository) : IRequestHandler<UpdateInvoiceCommand, UpdateInvoiceCommandResponse>
    {
        public async Task<UpdateInvoiceCommandResponse> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {


            var invoice = repository.GetById(request.Id);
            if (invoice == null)
            {
                throw new Exception("invoce not found");

            }
            invoice.Update(request.status, request.TrakingCode);
            repository.Update(invoice);

            return new UpdateInvoiceCommandResponse(invoice.Id);
        }
    }
}
