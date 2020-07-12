using SalesTaxWeb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesTaxWeb.Repository
{
    public class ItemEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsImported { get; set; }

        [Required]
        public bool HasSalesTax { get; set; }

        [Required]
        public string ItemType { get; set; }

        [Required]
        public List<ItemType> ItemTypes { get; set; }
    }
}
