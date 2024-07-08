﻿using Application.Products.CreateProduct;
using Domain.Products.Repository;
using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Invoices.Repository;
using Domain.Invoices;

namespace Application.Invoices.CreateInvoice
{
    public record CreateInvoiceCommandResponse(int Id);

    public record CreateInvoiceCommand(int addressId, decimal discount) : IRequest<CreateInvoiceCommandResponse>;


    public class CreateInvoiceCommandHandler(IInvoiveRepository repository) : IRequestHandler<CreateInvoiceCommand, CreateInvoiceCommandResponse>
    {
        public async Task<CreateInvoiceCommandResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoce = Invoice.Create(request.addressId,request.discount);
            var id = repository.Create(invoce);

            return new CreateInvoiceCommandResponse(id);
        }
    }

}
