using Domain.Invoices.Repository;
using MediatR;

namespace Application.Carts.GetCarts
{
    public class GetCartSHandler : IRequestHandler<GetCartSQuery, IReadOnlyCollection<GetCartSQueryResponse>>
    {
        private ICratRepository _repo;
        public GetCartSHandler(ICratRepository Repo)
        {
            _repo = Repo;
        }
        public async Task<IReadOnlyCollection<GetCartSQueryResponse>> Handle(GetCartSQuery request, CancellationToken cancellationToken)
        {
            var carts = _repo.GetPaged(request.PageNo, request.PageSize);
            return carts.Select(cart => (GetCartSQueryResponse)cart).ToList();
        }
    }

}
