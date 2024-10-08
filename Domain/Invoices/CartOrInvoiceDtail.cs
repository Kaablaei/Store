﻿using Ardalis.GuardClauses;
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
        public Invoice invoice { get; set; }
        public int? InvoiceId { get; set; }
        public int Count { get; set; }
        public int VaridationId { get; set; }
        public Variation variation { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }

   
        public void Update(decimal Price, decimal SalePrice, int count, int varidationId)
        {
            this.SalePrice = SalePrice;
            this.Price = Price;
            Count = count;
            VaridationId = varidationId;
        }

        public static CartOrInvoiceDtail Create(int userid, int validationid, decimal price, decimal saleprice, int count)
        {
            price = Guard.Against.NegativeOrZero(price);
            saleprice = Guard.Against.NegativeOrZero(saleprice);
            return new CartOrInvoiceDtail
            {
                CreateOn = DateTime.UtcNow,
                CratetdAgent = "",
                CreatedIP = "",
                ModifyAgent = "",
                ModifyIP = "",

                UserId = userid,
                VaridationId = validationid,
                Price = price,
                SalePrice = saleprice,
                Count = count
            };

        }
        public void Update(int userid, int validationid, decimal price, decimal saleprice)
        {
            UserId = userid;
            VaridationId = validationid;
            Price = price;
            SalePrice = saleprice;

        }



    }
}
