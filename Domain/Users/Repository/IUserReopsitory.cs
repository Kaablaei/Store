

namespace Domain.Users.Repository
{
    public interface IUserReopsitory
    {

        int Create(User user);

        int Update(User user);
        User GetById(int id, bool tracking=false);
        IReadOnlyCollection<User> GetPaged(int pageNo, int pageSize);

        void Delete(int id);


    }
}
