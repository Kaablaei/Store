using Domain.Users;

namespace Application.Users.GetAll
{
    public record GetUsersQueryResponse(int Id, string email, string name)
    {
        public static explicit operator GetUsersQueryResponse(User user)

        {

            return new GetUsersQueryResponse(user.Id, user.Email, user.Name);
        }
    }

}
