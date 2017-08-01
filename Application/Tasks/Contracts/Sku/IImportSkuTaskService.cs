using System.Threading.Tasks;

namespace EcommercerCatalog.Application.Tasks.Contracts.Sku
{
    public interface IImportSkuTaskService
    {
        Task ImportSkus();
    }
}