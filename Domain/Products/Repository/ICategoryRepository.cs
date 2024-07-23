

namespace Domain.Products.Repository
{
    public interface ICategoryRepository
    {

        int Create(Category product);

        int Update(Category product);
        Category? GetById(int id, bool tracking = false);
        void Delete(int id);

        IReadOnlyCollection<Category> GetPaged(int pageNo, int pageSize);


    }
}
