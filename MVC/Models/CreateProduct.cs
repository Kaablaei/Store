using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class CreateProduct
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string sku { get; set; }
        public int categoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
