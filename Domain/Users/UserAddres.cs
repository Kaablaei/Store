using Domain.Base;
using Domain.Users;

namespace Domain.User
{
    public class UserAddres : BaseEntity<int>
    {


        
        public int UserId { get; set; }

        public Address Address { get; set; }

    }

}
