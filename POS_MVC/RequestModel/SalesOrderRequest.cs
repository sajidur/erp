using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.RequestModel
{
    public class SalesOrderRequest
    {
        public InventoryResponse Inventory { get; set; }
        public int Qty { get; set; }
    }
}