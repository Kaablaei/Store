namespace Domain.Products.Repository
{
    public interface IProductRepository
    {


        int Create(Product product);

        int Update(Product product);
        Product? GetById(int id, bool tracking = false);
        IReadOnlyCollection<Product> GetPaged(int pageNo, int pageSize);


        Task<bool> CheckExist(int categoryId);

        void Delete(int id);


    }
}
