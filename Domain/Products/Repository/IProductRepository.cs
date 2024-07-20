using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Repository
{
    public interface IProductRepository
    {


        int Create(Product product);

        int Update(Product product);
        Product? GetById(int id);
        IReadOnlyCollection<Product> GetPaged(int pageNo, int pageSize);

        void Delete(int id);


    }
}
