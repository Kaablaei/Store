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
    public record GetCategorysQuery(int PageNo, int PageSize) : IRequest<IReadOnlyCollection<GetCategurysQueryResponse>>;


    public record GetCategurysQueryResponse(int Id,string name)
    {

        public static explicit operator GetCategurysQueryResponse( Category category)
        {
            return new GetCategurysQueryResponse(category.Id,category.Name);
        }
    }

    public class GetCategoryQueryHandler : IRequestHandler<GetCategorysQuery, IReadOnlyCollection<GetCategurysQueryResponse>>
    {

        private ICategoryRepository _repo;
        public GetCategoryQueryHandler(ICategoryRepository Repo)
        {
            _repo = Repo;
        }

        public async Task<IReadOnlyCollection<GetCategurysQueryResponse>> Handle(GetCategorysQuery request, CancellationToken cancellationToken)
        {
            var category = _repo.GetPaged(request.PageNo,request.PageSize);
            return [.. category.Select(p => (GetCategurysQueryResponse)p)];
        }
    }
}
