using RexERP_MVC.ViewModel;

namespace RexERP_MVC.RequestModel
{
    public class SalesOrderRequest
    {
        public InventoryResponse Inventory { get; set; }
        public int Qty { get; set; }
    }
}