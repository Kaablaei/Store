using Domain.Invoices;
using Domain.Products;
using Domain.Users;

namespace API.DTOs
{
    public class CartsDto
    {
        public int UserId { get; set; }
        public int? InvoiceId { get; set; }
        public int Count { get; set; }
        public int VaridationId { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
    }
}
