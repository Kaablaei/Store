using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.GetProducts
{
    public record GetProductsQuery(int PageNo,int PageSize):IRequest<IReadOnlyCollection<GetProductsQueryResponse>>;
    
    
}
