using Application.Invoices.GetInvoices;
using Application.Users.GetAll;
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
}
