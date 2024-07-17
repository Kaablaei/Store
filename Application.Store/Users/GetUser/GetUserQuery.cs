using Application.Products.GetProduct;
using Application.Users.GetAll;
using Domain.Products;
using MediatR;
using System.Drawing;

namespace Application.Users.Get
{
    public record GetUserQuery(int Id):IRequest<GetUserQueryResponse>;



}
