using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Repository
{
    public interface IVariationRepository
    {
        int Create(Variation variation);

        int Update(Variation variation);
        Variation GetById(int id);
        IReadOnlyCollection<Variation> GetPaged(int pageNo, int pageSize);

        void Delete(int id);
    }
}
