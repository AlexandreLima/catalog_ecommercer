namespace EcommercerCatalog.Infraestruture.Configuration
{
    public class MongoConfigurationManager
    {
        public string MongoConnectionString { get; set; }
        public string MongoDatabaseName { get; set; }
        public string MongoCatalogCollection { get; set; }
    }
}