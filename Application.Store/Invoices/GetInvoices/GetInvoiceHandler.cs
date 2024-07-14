using Domain.Invoices.Repository;
using MediatR;

namespace Application.Invoices.GetInvoices
{
    public class GetInvoiceHandler : IRequestHandler<GetInvoicesSQuery,IReadOnlyCollection<GetInvoiceSQueryResponse>>
    {
        private IInvoiveRepository _repo;
        public GetInvoiceHandler(IInvoiveRepository Repo)
        {
            _repo = Repo;
        }

        public async Task<IReadOnlyCollection<GetInvoiceSQueryResponse>> Handle(GetInvoicesSQuery request, CancellationToken cancellationToken)
        {


            var invoice = _repo.GetPaged(request.PageNo, request.PageSize);
            return [.. invoice.Select(p => (GetInvoiceSQueryResponse)p)];
        }
    }

}
