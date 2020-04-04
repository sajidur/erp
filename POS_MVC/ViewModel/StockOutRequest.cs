using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class StockOutRequest
    {
        public int InventoryId { get; set; }
        public decimal Qty { get; set; }
    }
}