using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using EcommercerCatalog.Infraestruture.Data.DataBaseContext.Contracts;
using EcommercerCatalog.Infraestruture.Data.Repository.Contracts.Sku;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace EcommercerCatalog.Infraestruture.Data.Repository.Impl.Mongo.Sku
{
    public class SkuRepository : ISkuRepository
    {
        private ICatalogMongoDbContext catalogDbContext;
        
        public SkuRepository(ICatalogMongoDbContext catalogDbContext)
        {
            this.catalogDbContext = catalogDbContext;
        }
        
        public void Insert(Model.Catalog.Sku sku)
        {
            try
            {
                catalogDbContext.Skus.InsertOne(sku);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task<List<Model.Catalog.Sku>> GetAllBySearchQuery(string searchQuery)
        {
            var list =  await catalogDbContext
                                .Skus
                                .FindAsync(x => x.FindCategory ==  searchQuery);

            return await list.ToListAsync();
        }
    }
}