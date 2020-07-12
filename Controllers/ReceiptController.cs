using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesTaxWeb.Models;
using SalesTaxWeb.Business;


namespace SalesTaxWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiptController : ControllerBase
    {
        private IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService) {
            _receiptService = receiptService;
        }

        [HttpGet("GetItemTemplate")]
        public ItemTemplateApiResult GetItemTemplate()
        {
            return _receiptService.GetItemTemplate();
        }

        [HttpPost("GetReceipt")]
        public ReceiptApiResult GetReceipt(List<Item> items)
        {
            //Sample test data - intentionally left here by developer to show testing data.
            //var items2 = new List<Item>();
            //items2.Add(new Item() { IsImported = false, HasSalesTax = false, Name = "Book", Price = 12.49M, Quantity = 1 });
            //items2.Add(new Item() { IsImported = false, HasSalesTax = false, Name = "Book", Price = 12.49M, Quantity = 1 });
            //items2.Add(new Item() { IsImported = false, HasSalesTax = true, Name = "Music CD", Price = 14.99M, Quantity = 1 });
            //items2.Add(new Item() { IsImported = false, HasSalesTax = false, Name = "Chocolate Bar", Price = 0.85M, Quantity = 1 });

            //items2.Add(new Item() { IsImported = true, HasSalesTax = true, Name = "Imported Perfume", Price = 27.99M, Quantity = 1 });
            //items2.Add(new Item() { IsImported = false, HasSalesTax = true, Name = "Perfume", Price = 18.99M, Quantity = 1 });
            //items2.Add(new Item() { IsImported = false, HasSalesTax = false, Name = "Headache Pills", Price = 9.75M, Quantity = 1 });
            //items2.Add(new Item() { IsImported = true, HasSalesTax = false, Name = "Imported Chocolates", Price = 11.25M, Quantity = 1 });
            //items2.Add(new Item() { IsImported = true, HasSalesTax = false, Name = "Imported Chocolates", Price = 11.25M, Quantity = 1 });


            //items2.Add(new Item() { IsImported = true, HasSalesTax = true, Name = "Book", Price = 1.50M, Quantity = 2 });    // dup
            //items2.Add(new Item() { IsImported = true, HasSalesTax = true, Name = "Book", Price = 1.50M, Quantity = 4 });    // dup
            //items2.Add(new Item() { IsImported = true, HasSalesTax = true, Name = "Book2", Price = 1.50M, Quantity = 2 });   
            //items2.Add(new Item() { IsImported = true, HasSalesTax = true, Name = "Book3", Price = 1.50M, Quantity = 2 });
            //items2.Add(new Item() { IsImported = true, HasSalesTax = true, Name = "Book3", Price = 1.60M, Quantity = 2 });
            //items2.Add(new Item() { IsImported = false, HasSalesTax = true, Name = "Book3", Price = 1.60M, Quantity = 2 });  //dup
            //items2.Add(new Item() { IsImported = false, HasSalesTax = true, Name = "Book3", Price = 1.60M, Quantity = 5 });  //dup
            //items2.Add(new Item() { IsImported = false, HasSalesTax = true, Name = "Book3", Price = 1.60M, Quantity = 3 });  //dup
            var receipt = _receiptService.GetReceipt(items);

            return receipt;
        }

    }
}
