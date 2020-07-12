using SalesTaxWeb.Models;
using System.Collections.Generic;

namespace SalesTaxWeb.Repository
{
    public interface ISalesTaxRepository
    {
        public ItemEntity GetItemTemplate();
        public List<ItemType> GetItemTypes();
    }
}
