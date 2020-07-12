namespace SalesTaxWeb.Repository
{
    public class Context
    {
        public ItemEntity Item 
        { 
            get {
                return new ItemEntity
                {
                    Id = -1,
                    Name = "",
                    Price = 0,
                    Quantity = 0,
                    IsImported = false,
                    HasSalesTax = false
                };
            }
        }

    }
}
