using Domain.Products.Repository;
using MediatR;

namespace Application.Products.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse>
    {
        private IProductRepository _repo;
        public GetProductQueryHandler(IProductRepository Repo )
        {
           _repo = Repo;
        }
        public async Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var product = _repo.GetById(request.Id);
            return (GetProductQueryResponse)product;


        }
    }
}
