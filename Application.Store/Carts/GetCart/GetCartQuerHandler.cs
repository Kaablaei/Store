using Domain.Invoices.Repository;
using MediatR;

namespace Application.Carts.GetCart
{
    public class GetCartQuerHandler : IRequestHandler<GetCartQuer, GetCartQueryResponse>
    {
        private ICratRepository _repo;
        public GetCartQuerHandler(ICratRepository repo)
        {
            _repo = repo;
        }
        public async Task<GetCartQueryResponse> Handle(GetCartQuer request, CancellationToken cancellationToken)
        {
          var cart = _repo.GetById(request.id);

            return (GetCartQueryResponse)cart;

        }
    }




}
