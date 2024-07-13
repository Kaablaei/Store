using Domain.Products;
using Domain.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categorys.GetCatrgory
{
    public record GetCategoryQuery(int Id) : IRequest<GetCategoryQueryResponse>;

    public record GetCategoryQueryResponse(int Id)
    {
        public static explicit operator GetCategoryQueryResponse(Category category)
        {

            return new GetCategoryQueryResponse(category.Id);
        }

    }

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
