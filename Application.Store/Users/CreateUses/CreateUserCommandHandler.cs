using Application.Products.CreateProduct;
using Domain.Products.Repository;
using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Repository;
using Domain.Users;

namespace Application.Users.Create
{

    public class CreateUserCommandHandler(IUserReopsitory repository) : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(request.name,request.family,request.phone,request.email);
            var id = repository.Create(user);

            return new CreateUserCommandResponse(id);
        }
    }
}
