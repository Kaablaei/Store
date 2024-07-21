using Ardalis.GuardClauses;
using Domain.Base;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Invoices
{
    public class Invoice : BaseEntity<int>
    {
        public string InvoiceNo { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int AdressId { get; set; }
        public Address Address { get; set; }



        //about address
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }




        public InvoiceStatus Statuse { get; set; }

        public string TrackingCode { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }

        public decimal PayableAmount { get; set; }
        public static Invoice Create(string InvoiceNo, int addressId, decimal discount)
        {
            discount = Guard.Against.NegativeOrZero(discount);
            return new Invoice
            {
                InvoiceNo = InvoiceNo,
                City = "",
                CratetdAgent = "",
                CreateOn = DateTime.UtcNow,
                CreatedIP = "",
                ModifyAgent = "",
                ModifyIP = "",
                PostalCode = "",
                State = "",
                TrackingCode = " ",

                AdressId = addressId,
                Discount = discount,
            };
        }


        public void Payed()
        {
            this.Statuse = InvoiceStatus.Payed;
            this.ModifiedOn = DateTime.UtcNow;
        }


        public void Update(string city, string state, string postalCode)
        {
            City = city;
            State = state;
            PostalCodem = postalCode;
        }
    }


}
