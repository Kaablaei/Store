using Domain.Base;
using Domain.Users;
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
        public User User { get ; set; } 

        public int ValidationId { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }




        //
        public static CartOrInvoiceDtail Create(int userid, int validationid, decimal price, decimal saleprice)
        {
            return new CartOrInvoiceDtail
            {
                UserId = userid,
                ValidationId = validationid,
                Price = price,
                SalePrice = saleprice
            };



        }

    }
}
