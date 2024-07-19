using Domain.Products;
using Domain.Products.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VariationRepository : BaseRepository<Variation>, IVariationRepository
    {
        public VariationRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
