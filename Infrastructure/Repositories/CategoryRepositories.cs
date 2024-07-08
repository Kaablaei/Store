using Domain.Products;
using Domain.Products.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
  

    public class CategoryRepositories : BaseRepository<Category>, ICategoryRepositories
    {
        public CategoryRepositories(ApplicationDbContext db) : base(db)
        {
        }


        public Category Sample()
        {
            return Category.Create("");
        }





    }
}
