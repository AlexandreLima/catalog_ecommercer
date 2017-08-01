using System.ComponentModel;
using System.Threading.Tasks;
using EcommercerCatalog.Application.Tasks.Contracts.Sku;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace EcommercerCatalog.Controllers
{
    [Route("api/[controller]")]
    public class ImportController : Controller
    {
        private IImportSkuTaskService _importSkuTaskService;
        public ImportController(IImportSkuTaskService importTaskService)
        {
            this._importSkuTaskService = importTaskService;
        }
        
        // GET
        public async Task Get()
        {
            BackgroundWorker back = new BackgroundWorker();
            back.DoWork += async (sender, args) => await this._importSkuTaskService.ImportSkus();

            back.RunWorkerAsync();
        }
    }
}