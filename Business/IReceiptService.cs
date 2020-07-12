using SalesTaxWeb.Models;
using SalesTaxWeb.Repository;
using System.Collections.Generic;

namespace SalesTaxWeb.Business
{
    public interface IReceiptService
    {
        public ReceiptApiResult GetReceipt(List<Item> items);

        public ItemTemplateApiResult GetItemTemplate();
    }
}
