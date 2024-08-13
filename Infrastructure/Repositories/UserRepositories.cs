using Domain.Users;
using Domain.Users.Repository;

namespace Infrastructure.Repositories
{
    public class UserRepositories : IUserReopsitory
    {
        private ApplicationDbContext _db;
        public UserRepositories(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user.Id;
        }

        public void Delete(int id)
        {
            var entity = _db.Users.Find(id);
            _db.Users.Remove(entity);
            _db.SaveChanges();
        }



        public User GetById(int id, bool tracking = false)
        {
            return _db.Users.SingleOrDefault(p => p.Id == id);
        }

        public IReadOnlyCollection<User> GetPaged(int pageNo, int pageSize)
        {
            return _db.Users

          .Skip((pageNo - 1) * pageSize)
          .Take(pageSize)
          .ToList();
        }

        public int Update(User user)
        {
            _db.Update(user);
            _db.SaveChanges();
            return user.Id;
        }
    }
}
