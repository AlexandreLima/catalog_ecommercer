using System.Collections.Generic;
using EcommercerCatalog.Model.Catalog;

namespace EcommercerCatalog.Model.Import
{
    public class Response
    {
        public string query { get; set; }
        public string sort { get; set; }
        public string responseGroup { get; set; }
        public int totalResults { get; set; }
        public int start { get; set; }
        public int numItems { get; set; }
        public List<Sku> items { get; set; }
        public List<object> facets { get; set; }
    }
}