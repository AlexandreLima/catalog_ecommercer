using System.Collections.Generic;

namespace EcommercerCatalog.Application.ServiceClient.Message.ImportSku
{
    public class ImportSkuNotificationMessageRequest
    {
        public int DataInicio { get; set; }
        public int DataFim { get; set; }
        public List<string> ImportedSkus { get; set; }
    }
}