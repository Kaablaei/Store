namespace Domain.Invoices.Repository
{
    public interface ICartRepository 
    {

        int Create(CartOrInvoiceDtail cartOrInvoiceDtail);

        int Update(CartOrInvoiceDtail cartOrInvoiceDtail);
        CartOrInvoiceDtail GetById(int id, bool tracking = false);
        IReadOnlyCollection<CartOrInvoiceDtail> GetPaged(int pageNo, int pageSize);

        void Delete(int id);
    }
 
}
