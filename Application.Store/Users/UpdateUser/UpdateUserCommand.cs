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
    public record UpdateUserCommand(int Id, string name, string family, string phone, string email) : IRequest<UpdateUserCommandResponse>;


    public record UpdateUserCommandResponse(int id);

    public class UpdateUserCommandHandler(IUserReopsitory repository) : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = repository.GetById(request.Id);

            user.Name = request.name;
            user.Family = request.family;
            user.Phone = request.phone;
            user.Email = request.email;

            repository.Update(user);

            return new UpdateUserCommandResponse(user.Id);
        }
    }
}