using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EcommercerCatalog.Application.Entity.Contracts;
using EcommercerCatalog.Application.Tasks.Contracts.Sku;
using EcommercerCatalog.Model.Import;
using Microsoft.AspNetCore.Hosting.Internal;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace EcommercerCatalog.Application.Tasks.Implements.Sku
{
    public class ImportSkuTaskService : IImportSkuTaskService
    {
        private ISkuEntityService _entityService;

        public ImportSkuTaskService(ISkuEntityService entityService)
        {
            this._entityService = entityService;
        }
        
        public async Task ImportSkus()
        {
            string[] buscas = new string[]
            {
                "notebook", "smartphone", "tablet", "Smart TVs", "jbl", "monitor", "4K Ultra HD TVs", 
                "Curved TVs", "3D TVs", "Camera", "Microwave", "Cooker"
            };

            string[] valores = new string[]
            {
                "price:[100 TO 150]", "price:[150 TO 200]", "price:[200 TO 250]", "price:[250 TO 300]", "price:[350 TO 400]",
                "price:[400 TO 450]", "price:[450 TO 500]", "price:[500 TO 550]", "price:[550 TO 600]", "price:[650 TO 700]",
                "price:[750 TO 800]", "price:[800 TO 850]", "price:[850 TO 900]", "price:[900 TO 950]", "price:[950 TO 1000]"
            };

            foreach (var query in buscas)
            {
                foreach (var range in valores)
                {
                    var response = this.ObterTiposSkus(query, range);
                    
                    if (response != null && response.items != null)
                    {
                        foreach (var sku in response.items)
                        {
                            sku.FindCategory = query;
                            _entityService.Incluir(sku);
                        }    
                    }
                }
            }
            
        }

        private Response ObterTiposSkus(string searchQuery, string valores)
        {
            searchQuery = System.Net.WebUtility.UrlEncode(searchQuery);
            valores = System.Net.WebUtility.UrlEncode(valores);
            
            string requestUri =
                $"/v1/search?query={searchQuery}&format=json&apiKey=brbwq2edkcjaxjjuj9vsw9nx&numItems=25&facet=on&facet.range={valores}"; 
            
            Response responseObj = null;
            
            using (var client = new HttpClient())
            {
                try
                {
                    
                    client.BaseAddress = new Uri("http://api.walmartlabs.com");
                    var response = client.GetAsync(requestUri).Result;
                    
                    response.EnsureSuccessStatusCode();
                    var stringResponse = response.Content.ReadAsStringAsync().Result;
                    
                    responseObj = JsonConvert.DeserializeObject<Response>(stringResponse);

                    return responseObj;

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message} {e.InnerException}");
                }
                catch(Exception e){  Console.WriteLine($"Request exception: {e.Message}");  }
            }
            
            return responseObj;
        }
    }
}