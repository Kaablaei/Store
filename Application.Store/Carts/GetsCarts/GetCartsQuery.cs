using Domain.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Carts.GetCarts
{
    public record GetCartSQuery(int PageNo, int PageSize) : IRequest<IReadOnlyCollection<GetCartSQueryResponse>>;

}
