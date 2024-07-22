using Domain.Invoices;
using Domain.Invoices.Repository;

namespace Infrastructure.Repositories
{
    public class InvoiceRepositories : BaseRepository<Invoice>, IInvoiveRepository
    {
        public InvoiceRepositories(ApplicationDbContext db) : base(db)
        {

        }


    } 


}
