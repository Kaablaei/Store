
namespace Application.Categorys.CreateCategory
{
    public interface IThirdParty
    {
        Task<long> SendSMS(int id, CancellationToken cancellationToken);
    }
}