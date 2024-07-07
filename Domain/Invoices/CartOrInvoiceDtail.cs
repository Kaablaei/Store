using Domain.Base;
using Domain.Products;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoices
{
    public class CartOrInvoiceDtail : BaseEntity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }


        //invoic
        public Invoice invoice { get; set; }

        public int? InvoiceId { get; set; }


        public int Count { get; set; }
        public int VaridationId { get; set; }
        public Variation variation { get; set; }
        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }
        public static CartOrInvoiceDtail Create(int userid, int validationid, decimal price, decimal saleprice)
        {
            return new CartOrInvoiceDtail
            {
                UserId = userid,
                VaridationId = validationid,
                Price = price,
                SalePrice = saleprice
            };

        }
    }
}
