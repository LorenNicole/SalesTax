using SalesTaxWeb.Models;
using SalesTaxWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxWeb.Business
{
    public class ReceiptService : IReceiptService
    {
        private ISalesTaxRepository _salesTaxRepository;

        public ReceiptService(ISalesTaxRepository salesTaxRepository)
        {
            _salesTaxRepository = salesTaxRepository;
        }

        public ItemTemplateApiResult GetItemTemplate()
        {
            var itemTemplate =_salesTaxRepository.GetItemTemplate();

            return new ItemTemplateApiResult
            {
                Id = itemTemplate.Id,
                Name = itemTemplate.Name,
                Price = itemTemplate.Price,
                Quantity = itemTemplate.Quantity,
                HasSalesTax = itemTemplate.HasSalesTax,
                IsImported = itemTemplate.IsImported,
                ItemType = itemTemplate.ItemType,
                ItemTypes = itemTemplate.ItemTypes
            };
        }

        public ReceiptApiResult GetReceipt(List<Item> items)
        {
            decimal importTax;
            decimal itemTotal;
            decimal receiptTotal = 0;
            decimal salesTax = 0;
            decimal salesTaxTotal = 0;
            decimal importTaxTotal = 0;
            decimal priceWithTax = 0;
            ReceiptApiResult receipt = new ReceiptApiResult() { ErrorMessage = string.Empty, ReceiptItems = new List<ItemReceipt>()};
            
            try {
                var consolidatedItems = ConsolidateDuplicateItems(items);
                consolidatedItems.Where(item => item.Quantity > 0).ToList().ForEach(item => {
                    ItemReceipt itemReceipt = new ItemReceipt();
                    salesTax = item.HasSalesTax ? GetSalesTax(item.Price) : 0;
                    salesTaxTotal += salesTax * item.Quantity;
                    importTax = item.IsImported ? GetImportTax(item.Price) : 0;
                    importTaxTotal += importTax * item.Quantity;
                    priceWithTax = item.Price + salesTax + importTax;
                    itemTotal = GetItemTotal(item.Price, item.Quantity, salesTax, importTax);
                    itemReceipt.Description = GetItemReceiptDescription(item.Name, item.Quantity, itemTotal, priceWithTax);
                    receipt.ReceiptItems.Add(itemReceipt);
                    receiptTotal += itemTotal;
                });

                receipt.Total = $"Total: {receiptTotal.ToString("C")}";
                receipt.SalesTax = $"Sales Tax: {(salesTaxTotal + importTaxTotal).ToString("C")}";
            }
            catch (System.Exception exc)
            {
                receipt.ErrorMessage = $"Unable to process receipt. Error - {exc.Message}";
                return receipt;
            }

            return receipt;
        }

        private List<Item> ConsolidateDuplicateItems(List<Item> originalItems)
        {
            List<Item> consolidatedItems = new List<Item>();
            
            var uniqueItems = originalItems.Select(item => new { Name = item.Name.Trim(), Price = item.Price, HasSalesTax = item.HasSalesTax, IsImported = item.IsImported, item.ItemType }).Distinct();
            uniqueItems.ToList().ForEach(item => {
                var quantity = originalItems.Where(x => 
                    x.Name == item.Name && 
                    x.Price == item.Price && 
                    x.HasSalesTax == item.HasSalesTax && 
                    x.IsImported == item.IsImported &&
                    x.ItemType == item.ItemType).Select(y => y.Quantity).Sum();
                
                consolidatedItems.Add(new Item
                {
                    Name = item.Name,
                    Price = item.Price,
                    HasSalesTax = AssignItemTaxStatus(item.ItemType),
                    IsImported = item.IsImported,
                    Quantity = quantity
                }); ;
            });

            return consolidatedItems;
        }

        private bool AssignItemTaxStatus(string itemType)
        {
            var hasSalesTax = _salesTaxRepository.GetItemTypes().First(item => item.Type == itemType)?.HasSalesTax;
            return hasSalesTax ?? false;
        }

        private decimal GetCost(decimal price, int quantity)
        {
            return price * quantity;
        }

        private decimal GetSalesTax(decimal cost)
        {
            decimal salesTaxAmount = 0.10M;
            var salexTax = Decimal.Round(cost * salesTaxAmount, 2);
            return RoundUp(salexTax);
        }

        private decimal GetImportTax(decimal cost)
        {
            decimal importTaxAmount = 0.05M;
            var importTax = Decimal.Round(cost * importTaxAmount, 2);
            return RoundUp(importTax);
        }

        private decimal RoundUp(decimal cost)
        {
            //Round up to nearest $.05 cents.
            return Math.Ceiling(cost * 20) / 20;
        }

        private decimal GetItemTotal(decimal cost, int quantity, decimal salesTax, decimal importTax)
        {
            return (cost + salesTax + importTax) * quantity;
        }

        private string GetItemReceiptDescription(string Name, int Quantity, decimal itemTotal, decimal Price)
        {
            var multipleItems = Quantity > 1 ? $"({Quantity} @ {Price.ToString("C")})" : null;
            return $"{Name}: {itemTotal.ToString("C")} {multipleItems ?? ""}";
        }

    }
}
