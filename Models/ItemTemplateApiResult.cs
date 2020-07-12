using System.Collections.Generic;

namespace SalesTaxWeb.Models
{
    public class ItemTemplateApiResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsImported { get; set; }
        public bool HasSalesTax { get; set; }
        public string ItemType { get; set; }
        public List<ItemType> ItemTypes { get; set; }
    }
}
