using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoices
{
    public class CartOrInvoiceDtail : BaseEntity<int>
    {
        public int UserId { get; set; }

        public int ValidationId { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

    }
}
