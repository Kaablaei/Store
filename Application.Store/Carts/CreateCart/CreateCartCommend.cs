using Application.Categorys.CreateCategory;
using Application.Products.CreateProduct;
using Domain.Products.Repository;
using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Users.Create;

namespace Application.Carts.CreateCart
{
    public record CreateCartCommend(int userid, int validationid, decimal price, decimal saleprice): IRequest<CreateCartCommandResponse>;

}
