using Domain.Users;
using Domain.Users.Repository;

namespace Infrastructure.Repositories
{
    public class UserRepositories : BaseRepository<User>, IUserReopsitory
    {
        public UserRepositories(ApplicationDbContext db) : base(db)
        {
            
        }

    }
}
