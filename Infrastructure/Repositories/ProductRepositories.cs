using Domain.Products.Repository;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Repository;

namespace Infrastructure.Repositories
{
    public class ProductRepositories : BaseRepository<Product>, IProductRepository
    {

        public ProductRepositories(ApplicationDbContext db) : base(db)
        {

        }
    }


}
