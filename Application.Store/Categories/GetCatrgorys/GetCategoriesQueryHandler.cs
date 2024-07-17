using Domain.Products.Repository;
using MediatR;

namespace Application.Categorys.GetCatrgorys
{
    public class GetCategoriesQueryHandler : IRequestHandler<CategoriesQuery, IReadOnlyCollection<GetCategoriesQueryResponse>>
    {

        private ICategoryRepository _repo;
        public GetCategoriesQueryHandler(ICategoryRepository Repo)
        {
            _repo = Repo;
        }

        public async Task<IReadOnlyCollection<GetCategoriesQueryResponse>> Handle(CategoriesQuery request, CancellationToken cancellationToken)
        {
            var category = _repo.GetPaged(request.PageNo,request.PageSize);
            return [.. category.Select(p => (GetCategoriesQueryResponse)p)];
        }
    }
}
