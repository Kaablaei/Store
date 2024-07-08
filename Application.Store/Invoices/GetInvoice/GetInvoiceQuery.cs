using Domain.Invoices.Repository;
using Domain.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Get
{
    public record GetInvoiceQuery(int id) : IRequest<GetInvoiceQueryResponse>;
    public record GetInvoiceQueryResponse(int id) { }


    public class GetInvoiceHandler : IRequestHandler<GetInvoiceQuery, GetInvoiceQueryResponse>
    {
        private IInvoiveRepository _repo;
        public GetInvoiceHandler(IInvoiveRepository Repo)
        {
            _repo = Repo;
        }

        public async Task<GetInvoiceQueryResponse> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {

            var invoice = _repo.GetById(request.id);

            return new GetInvoiceQueryResponse(invoice.Id);

        }
    }

}
