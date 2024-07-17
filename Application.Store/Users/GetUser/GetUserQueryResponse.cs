using Domain.Users;

namespace Application.Users.Get
{
    public record GetUserQueryResponse(int Id,string name)
    {
        public static explicit operator GetUserQueryResponse(User user)

        {

            return new GetUserQueryResponse(user.Id, user.Name);
        }
    }



}
