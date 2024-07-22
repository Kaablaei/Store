using Application.Products.UpdateProduct;
using Domain.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.UpdateUser
{
    public record UpdateUserCommand(int Id, string name, string family) : IRequest<UpdateUserCommandResponse>;


    public record UpdateUserCommandResponse(int id);

    public class UpdateUserCommandHandler(IUserReopsitory repository) : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = repository.GetById(request.Id,true);

            if (user == null)
                throw new NullReferenceException(nameof(request.Id));

            else
            {
                user.Update(request.name, request.family);
                repository.Update(user);
                return new UpdateUserCommandResponse(user.Id);

            }
        }
    }
}