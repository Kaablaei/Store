using Application.Users.Get;
using Domain.Invoices;
using Domain.Invoices.Repository;
using Domain.Users;
using Domain.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Get
{
    public record GetInvoiceQuery(int Id) : IRequest<GetInvoiceQueryResponse>;
    public record GetInvoiceQueryResponse(int Id , string InvoiceNo)
    {
        public static explicit operator GetInvoiceQueryResponse(Invoice invoice)

        {

            return new GetInvoiceQueryResponse(invoice.Id,invoice.InvoiceNo);
        }


    }


    public class GetInvoiceHandler : IRequestHandler<GetInvoiceQuery, GetInvoiceQueryResponse>
    {
        private IInvoiveRepository _repo;
        public GetInvoiceHandler(IInvoiveRepository Repo)
        {
            _repo = Repo;
        }

        public async Task<GetInvoiceQueryResponse> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoice = _repo.GetById(request.Id);

            return (GetInvoiceQueryResponse)invoice;

        }
    }

}
