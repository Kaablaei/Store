using Domain.Invoices.Repository;
using MediatR;

namespace Application.Invoices.Get
{
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
