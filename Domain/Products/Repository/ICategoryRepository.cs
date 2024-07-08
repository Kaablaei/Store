using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Repository
{
    public interface ICategoryRepository
    {

        int Create(Category product);

        int Update(Category product);
        Category GetById(int id);
        void Delete(int id);

        IReadOnlyCollection<Category> GetPaged(int pageNo, int pageSize);


    }
}
