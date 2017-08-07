using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommercerCatalog.Infraestruture.Data.Repository.Contracts.Sku
{
    public interface ISkuRepository
    {
        void Insert(Model.Catalog.Sku sku);

        Task<List<Model.Catalog.Sku>> GetAllBySearchQuery(string searchQuery);
    }
}