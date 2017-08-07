using System.Collections.Generic;
using System.Threading.Tasks;
using EcommercerCatalog.Application.Entity.Contracts;
using EcommercerCatalog.Model.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace EcommercerCatalog.Controllers
{
    [Route("api/[controller]")]
    public class SkuController : Controller
    {
        private ISkuEntityService skuEntityService;
        public SkuController(ISkuEntityService skuEntityService)
        {
            this.skuEntityService = skuEntityService;
        }
        
        [HttpGet("get/category")]
        public async Task<List<Sku>> GetByCategory(string searchQuery)
        {
            return await this.skuEntityService.FindByGroup(searchQuery);
        }
        
    }
}