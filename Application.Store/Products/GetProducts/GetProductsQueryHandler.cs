using Application.Products.GetProduct;
using Domain.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IReadOnlyCollection<GetProductsQueryResponse>>
    {
        private IProductRepository _repo;
        public GetProductsQueryHandler(IProductRepository Repo)
        {
            _repo = Repo;
        }
        public async Task<IReadOnlyCollection<GetProductsQueryResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var products = _repo.GetPaged(request.PageNo, request.PageSize);
            return [.. products.Select(p => (GetProductsQueryResponse)p)];

        }
    }
}
