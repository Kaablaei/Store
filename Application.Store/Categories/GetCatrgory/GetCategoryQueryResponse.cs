using Domain.Products;

namespace Application.Categorys.GetCatrgory
{
    public record GetCategoryQueryResponse(int Id, string Name)
    {
        public static explicit operator GetCategoryQueryResponse(Category category)
        {
            return new GetCategoryQueryResponse(category.Id, category.Name);
        }

    }

}
