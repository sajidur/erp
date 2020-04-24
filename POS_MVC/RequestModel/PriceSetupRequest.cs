using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.RequestModel
{
    public class PriceSetupRequest
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal ProductionPrice { get; set; }
        public decimal SalesPrice { get; set; }
    }
}