using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoices.Repository
{
    public interface ICratRepository 
    {

        int Create(CartOrInvoiceDtail cartOrInvoiceDtail);

        int Update(CartOrInvoiceDtail cartOrInvoiceDtail);
        CartOrInvoiceDtail GetById(int id);
        IReadOnlyCollection<CartOrInvoiceDtail> GetPaged(int pageNo, int pageSize);

        void Delete(int id);
    }
 
}
