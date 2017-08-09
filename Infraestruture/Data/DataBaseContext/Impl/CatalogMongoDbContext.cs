using EcommercerCatalog.Infraestruture.Configuration;
using EcommercerCatalog.Infraestruture.Data.DataBaseContext.Contracts;
using EcommercerCatalog.Model.Catalog;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace EcommercerCatalog.Infraestruture.Data.DataBaseContext.Impl
{
    public class CatalogMongoDbContext : ICatalogMongoDbContext
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _mongoDatabase;
        private string skuCollectionName = "skuCollection";
        public CatalogMongoDbContext()
        {
           this._mongoClient = new MongoClient("mongodb://localhost:27017");
           this._mongoDatabase = _mongoClient.GetDatabase("CatalogDb");
        }


        public IMongoCollection<Sku> Skus
        {
            get
            {
                return this._mongoDatabase.GetCollection<Sku>(skuCollectionName);
            }
        }
    }
}