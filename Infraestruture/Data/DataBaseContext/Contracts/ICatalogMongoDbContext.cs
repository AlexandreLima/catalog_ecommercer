using EcommercerCatalog.Model.Catalog;
using MongoDB.Driver;

namespace EcommercerCatalog.Infraestruture.Data.DataBaseContext.Contracts
{
    public interface ICatalogMongoDbContext
    {
        IMongoCollection<Sku> Skus { get; }
    }
}