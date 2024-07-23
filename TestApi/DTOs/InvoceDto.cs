using Domain.Users;
using Domain;

namespace API.DTOs
{
    public class InvoceDto
    {
        public string InvoiceNo { get; set; }
        public int UserId { get; set; }
        public int AdressId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public InvoiceStatus Statuse { get; set; }

        public string TrackingCode { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
