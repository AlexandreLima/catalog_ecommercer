using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using EcommercerCatalog.Infraestruture.Data.Repository.Contracts.Sku;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace EcommercerCatalog.Infraestruture.Data.Repository.Impl.Mongo.Sku
{
    public class SkuRepository : ISkuRepository
    {
        private MongoClient _mongoClient;
        private MongoServer _mongoServer;
        private MongoDatabase _mongoDatabase;
        public IMongoCollection<Model.Catalog.Sku> Collection;
        private const string collectionName = "SkuCollection"; 
        
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
                _mongoDatabase.GetCollection(collectionName).Save(sku);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public List<Model.Catalog.Sku> GetAllBySearchQuery(string searchQuery)
        {
            var collection = _mongoDatabase.GetCollection<Model.Catalog.Sku>(collectionName);
            var filter = Builders<Model.Catalog.Sku>.Filter.Eq("FindCategory", searchQuery);
            return collection.Find(Query.EQ("FindCategory", searchQuery)).ToList();
        }
    }
}