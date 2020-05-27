using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;
using RexERP_MVC.Util;
using RexERP_MVC.ViewModel;

namespace RexERP_MVC.BAL
{
    public class StockOutService
    {
        DBService<StockOut> service = new DBService<StockOut>();
        DBService<Inventory> inventory = new DBService<Inventory>();
        DBService<InventoryTransaction> _invTransactionService = new DBService<InventoryTransaction>();

        public List<StockOut> GetAll()
        {
            return service.GetAll();
        }
        public List<string> GetAllStockChallan()
        {
            DateTime fromDate = DateTime.Now.AddMonths(-1);
            return service.GetAll(a=>a.ProductionDate>fromDate && a.AlreadyProcessed==false).OrderBy(a=>a.ProductionDate).Select(a=>a.InvoiceNo).Distinct().ToList();
            //List<SqlParameter> parameters = new List<SqlParameter>();
            //SqlParameter param1 = new SqlParameter("@fromDate", DateTime.Now.AddMonths(-1));
            //parameters.Add(param1);
            //SqlParameter param2 = new SqlParameter("@toDate", DateTime.Now);
            //parameters.Add(param2);
            //var get = service.ExecuteProcedure("Exec StockOutChallanList @fromDate,@toDate", parameters);
            //return get;
        }
        public List<StockOut> GetStockChallan(string invoiceNo )
        {
            return service.GetAll(a => a.InvoiceNo==invoiceNo).ToList();
            //List<SqlParameter> parameters = new List<SqlParameter>();
            //SqlParameter param1 = new SqlParameter("@fromDate", DateTime.Now.AddMonths(-1));
            //parameters.Add(param1);
            //SqlParameter param2 = new SqlParameter("@toDate", DateTime.Now);
            //parameters.Add(param2);
            //var get = service.ExecuteProcedure("Exec StockOutChallanList @fromDate,@toDate", parameters);
            //return get;
        }


        public StockOut GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public bool Save(List<StockOutRequest> stockOuts,string invoiceNo,string Notes)
        {
            var balance = 0.0m;
            var inventoryLists = stockOuts.Select(a => a.InventoryId).ToList();
            var existingItem = inventory.GetAll(a => inventoryLists.Contains(a.Id) && a.IsActive == true).ToList();
            if (existingItem.Count > 0)
            {
                var stocks = new List<StockOut>();
                foreach (var inv in existingItem)
                {
                    var qty = stockOuts.Where(a => a.InventoryId == inv.Id).Sum(a => a.Qty);
                    var stock = new StockOut()
                    {
                        AlreadyProcessed = false,
                        BaleQty = qty,
                        ProductId = inv.ProductId,
                        IsActive = true,
                        InvoiceNo = invoiceNo,
                        Notes = Notes,
                        SupplierId = inv.SupplierId,
                        WarehouseId = inv.WarehouseId,
                        CreatedBy = CurrentSession.GetCurrentSession().UserName,
                        CreatedDate = DateTime.Now,
                        SizeId = inv.SizeId,
                        SizeName = inv.Size.Name,
                        BrandId = inv.BrandId,
                        BrandName = inv.Brand.BrandName,
                        APIId = inv.APIId,
                        InventoryId = inv.Id,
                        Rate = inv.PurchasePrice,
                        StockOutPrice = inv.PurchasePrice * qty,
                        ProductionDate=DateTime.Now
                    };
                    inv.UpdatedDate = DateTime.Now;
                    inv.UpdatedBy = CurrentSession.GetCurrentSession().UserName;
                    inv.ProductionOut+= qty;
                    inv.BalanceQty = inv.BalanceQty - qty;
                    balance = inv.BalanceQty;
                    inventory.Update(inv, inv.Id);
                    stocks.Add(stock);
                    var invTransaction = new InventoryTransaction()
                    {
                        APIId = stock.APIId,
                        BalanceQty = balance,
                        BrandId = stock.BrandId,
                        CreatedBy = CurrentSession.GetCurrentSession().UserName,
                        CreatedDate = DateTime.Now,
                        GoodsType = "Finished Goods",
                        InventoryGuid = Guid.NewGuid().ToString(),
                        InvoiceNo = "",
                        IsActive = true,
                        ProductId = stock.ProductId ?? 0,
                        PurchasePrice = 0,
                        Qty = stock.BaleQty,
                        SalesPrice = 0,
                        SizeId = stock.SizeId,
                        SupplierId = stock.SupplierId ?? 0,

                        TransactionType = (int)Util.TransactionType.ProductionOut,
                        WarehouseId = stock.WarehouseId ?? 0
                    };
                    _invTransactionService.Save(invTransaction);
                }
                service.Save(stocks);
                return true;
            }
            else
            {
                return false;
            }
        }

        public StockOut Update(StockOut t, int id)
        {
            return service.Update(t, id);

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}