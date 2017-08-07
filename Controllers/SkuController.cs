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
        
        [HttpGet]
        public async Task<List<Sku>> ObterSkusPorGrupo(string searchQuery)
        {
            return await this.skuEntityService.FindByGroup(searchQuery);
        }
        
    }
}