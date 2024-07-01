using Domain.Base;

namespace Domain.Products
{
    public class Tags : BaseEntity<int>
    {
       

        public string TagContent { get; set; }

        //
        public int ProductId { get; set; }


    }
}


