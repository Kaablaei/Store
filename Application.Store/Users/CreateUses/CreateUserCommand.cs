using MediatR;

namespace Application.Users.Create
{
    public record CreateUserCommand(string name, string family, string phone, string email) : IRequest<CreateUserCommandResponse>;
}
