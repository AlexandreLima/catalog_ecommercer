using System;
using System.Runtime.InteropServices.ComTypes;
using EcommercerCatalog.Infraestruture.Data.Repository.Contracts.Sku;
using MongoDB.Driver;

namespace EcommercerCatalog.Infraestruture.Data.Repository.Impl.Mongo.Sku
{
    public class SkuRepository : ISkuRepository
    {
        private MongoClient _mongoClient;
        private MongoServer _mongoServer;
        private MongoDatabase _mongoDatabase;
        
        public SkuRepository()
        {
            this._mongoClient = new MongoClient("mongodb://localhost:27017");
            this._mongoServer = _mongoClient.GetServer();
            this._mongoDatabase = _mongoServer.GetDatabase("CatalogDb");
        }
        
        public void Insert(Model.Catalog.Sku sku)
        {
            try
            {
                _mongoDatabase.GetCollection("SkuCollection").Save(sku);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}