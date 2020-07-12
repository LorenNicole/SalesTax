namespace SalesTaxWeb.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsImported { get; set; }
        public bool HasSalesTax { get; set; }
        public string ItemType { get; set; }
    }
}
