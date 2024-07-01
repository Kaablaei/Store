using Domain.Invoices;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users.Repository
{
    public interface IUserReopsitory
    {

        int Create(User.User user);

        int Update(User.User user);
        User.User GetById(int id);
        IReadOnlyCollection<User.User> GetPaged(int pageNo, int pageSize);

        void Delete(int id);


    }
}
