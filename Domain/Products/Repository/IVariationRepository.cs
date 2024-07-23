namespace Domain.Products.Repository
{
    public interface IVariationRepository
    {
        int Create(Variation variation);

        int Update(Variation variation);
        Variation GetById(int id, bool tracking = false);
        IReadOnlyCollection<Variation> GetPaged(int pageNo, int pageSize);

        void Delete(int id);
    }
}
