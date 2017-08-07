using System.Collections.Generic;
using System.Threading.Tasks;
using EcommercerCatalog.Application.Entity.Contracts;
using EcommercerCatalog.Infraestruture.Data.Repository.Contracts.Sku;
using EcommercerCatalog.Model.Catalog;

namespace EcommercerCatalog.Application.Entity.Implementation
{
    public class SkuEntityService : ISkuEntityService
    {
        private ISkuRepository repository;
        public SkuEntityService(ISkuRepository repository)
        {
            this.repository = repository;
        }
        
        public void Incluir(Sku sku)
        {
            repository.Insert(sku);
        }

        public async Task<List<Sku>> FindByGroup(string group)
        {
            return  await repository.GetAllBySearchQuery(group);
        }
    }
}