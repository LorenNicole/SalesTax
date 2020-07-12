using SalesTaxWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxWeb.Repository
{
    public class SalesTaxRepository : ISalesTaxRepository
    {               
        public ItemEntity GetItemTemplate()
        {
            var itemTypes = GetItemTypes();

            return new ItemEntity {
                Id = -1,
                Name = "",
                Price = 0,
                Quantity = 0,
                HasSalesTax = false,
                IsImported = false,
                ItemType = itemTypes.First(item => item.HasSalesTax == true).Type,
                ItemTypes = itemTypes
            };
        }

        public List<ItemType> GetItemTypes()
        {
            return new ItemTypes().Types;
        }
    }
}
