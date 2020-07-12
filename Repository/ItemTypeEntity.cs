using SalesTaxWeb.Models;
using System.Collections.Generic;

namespace SalesTaxWeb.Repository
{ 
    
    public class ItemTypes
    {        
        public List<ItemType> Types { 
            get {
                return new List<ItemType>
                    { new ItemType { Type = "Book", HasSalesTax = false },
                      new ItemType { Type = "Food", HasSalesTax = false },
                      new ItemType { Type = "Medical", HasSalesTax = false },
                      new ItemType { Type = "Other", HasSalesTax = true }
                };
            }
        }
    }
}
