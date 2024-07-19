using Domain.Invoices.Repository;
using MediatR;

namespace Application.Invoices.GetInvoices
{
    public class GetInvoicesHandler : IRequestHandler<GetInvoicesQuery,IReadOnlyCollection<GetInvoiceSQueryResponse>>
    {
        private IInvoiveRepository _repo;
        public GetInvoicesHandler(IInvoiveRepository Repo)
        {
            _repo = Repo;
        }

        public async Task<IReadOnlyCollection<GetInvoiceSQueryResponse>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {


            var invoice = _repo.GetPaged(request.PageNo, request.PageSize);
            return [.. invoice.Select(p => (GetInvoiceSQueryResponse)p)];
        }
    }

}
