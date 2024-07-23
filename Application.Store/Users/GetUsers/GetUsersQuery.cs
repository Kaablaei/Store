using Application.Products.GetProducts;
using Domain.Products;
using MediatR;
using System.Collections.ObjectModel;

namespace Application.Users.GetAll
{
    public record GetUsersQuery(int PageNo, int PageSize) : IRequest<IReadOnlyCollection<GetUsersQueryResponse>>;

}
