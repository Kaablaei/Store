using Domain.Invoices;
using Domain.Invoices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CartRepository  : BaseRepository<CartOrInvoiceDtail> , ICartRepository
    {

        public CartRepository(ApplicationDbContext db) : base(db)
        {
            
        }
    }
}
