using Application.Invoices.GetInvoices;
using Application.Users.GetAll;
using Domain.Products;
using Domain.Products.Repository;
using Domain.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categorys.GetCatrgorys
{
    public record CategoriesQuery(int PageNo, int PageSize) : IRequest<IReadOnlyCollection<GetCategoriesQueryResponse>>;

    //Categories
    public record GetCategoriesQueryResponse(int Id,string name)
    {

        public static explicit operator GetCategoriesQueryResponse( Category category)
        {
            return new GetCategoriesQueryResponse(category.Id,category.Name);
        }
    }

 
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
