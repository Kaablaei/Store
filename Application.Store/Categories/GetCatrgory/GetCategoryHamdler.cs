using Domain.Products.Repository;
using MediatR;

namespace Application.Categorys.GetCatrgory
{
    public class GetCategoryHamdler : IRequestHandler<GetCategoryQuery, GetCategoryQueryResponse>
    {
        private ICategoryRepository _repo;
        public GetCategoryHamdler(ICategoryRepository Repo)
        {
            _repo = Repo;
        }

        public async Task<GetCategoryQueryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var cagory = _repo.GetById(request.Id);
            return (GetCategoryQueryResponse)cagory;

        }
    }

}
