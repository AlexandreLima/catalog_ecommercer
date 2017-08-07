using System.Collections.Generic;
using System.Threading.Tasks;
using EcommercerCatalog.Model.Catalog;

namespace EcommercerCatalog.Application.Entity.Contracts
{
    public interface ISkuEntityService
    {
        void Incluir(Sku sku);

        Task<List<Sku>> FindByGroup(string group);
    }
}