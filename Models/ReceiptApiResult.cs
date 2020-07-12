using System.Collections.Generic;

namespace SalesTaxWeb.Models
{
    public class ReceiptApiResult
    {
        public List<ItemReceipt> ReceiptItems { get; set; }
        public string SalesTax { get; set; }
        public string Total { get; set; }
        public string ErrorMessage { get; set; }
    }
}
