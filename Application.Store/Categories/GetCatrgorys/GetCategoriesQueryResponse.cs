using Domain.Products;

namespace Application.Categorys.GetCatrgorys
{
    //Categories
    public record GetCategoriesQueryResponse(int Id,string name)
    {

        public static explicit operator GetCategoriesQueryResponse( Category category)
        {
            return new GetCategoriesQueryResponse(category.Id,category.Name);
        }
    }
}
