namespace Domain.Products.Repository
{
    public interface IVariationRepository
    {
        int Create(Variation variation);

        int Update(Variation variation);
        Variation GetById(int id, bool tracking = false);
        IReadOnlyCollection<Variation> GetPaged(int pageNo, int pageSize);

        Task<bool> CheckExist(int categoryId);

        void Delete(int id);
    }
}
