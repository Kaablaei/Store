
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoices.Repository
{
    public interface IInvoiveRepository
    {
        int Create(Invoice invoice);

       int Update(Invoice invoice);
        Invoice GetById(int id);
        IReadOnlyCollection<Invoice> GetPaged(int pageNo, int pageSize);

        void Delete(int id);


    }

}
