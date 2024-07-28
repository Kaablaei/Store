using Application.Categories.DeleteCategory;
using Domain.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DeleteUser
{
    public record DeleteUserCommand(int Id) : IRequest<DeleteUserCommandResponse>;

    public record DeleteUserCommandResponse(int Id);
    public class DeleteUserCommandHandler(IUserReopsitory repository) : IRequestHandler<DeleteUserCommand, DeleteUserCommandResponse>
    {
        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = repository.GetById(request.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            int id = request.Id;
            repository.Delete(id);

                return new DeleteUserCommandResponse(id);
            }
        }
    }


