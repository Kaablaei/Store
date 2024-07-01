using Domain.Base;

namespace Domain.Products
{
    public class Gallary : BaseEntity<int>
    {
       
        //
        public int ProductId { get; set; }

        public string Image { get; set; }

    }
}


