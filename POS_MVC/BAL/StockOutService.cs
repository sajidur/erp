using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RexERP_MVC.Models;
using RexERP_MVC.Util;
using System.Data.SqlClient;
using RexERP_MVC.ViewModel;

namespace RexERP_MVC.BAL
{
    public class StockOutService
    {
        DBService<StockOut> service = new DBService<StockOut>();
        DBService<Inventory> inventory = new DBService<Inventory>();

        public List<StockOut> GetAll()
        {
            return service.GetAll();
        }
        public List<string> GetAllStockChallan()
        {
            DateTime fromDate = DateTime.Now.AddMonths(-1);
            return service.GetAll(a=>a.ProductionDate>fromDate).OrderBy(a=>a.ProductionDate).Select(a=>a.InvoiceNo).Distinct().ToList();
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
                        SizeId=inv.SizeId,
                        SizeName=inv.Size.Name,
                        BrandId=inv.BrandId,
                        BrandName=inv.Brand.BrandName,
                        InventoryId=inv.Id,
                        ProductionDate=DateTime.Now
                    };
                    inv.UpdatedDate = DateTime.Now;
                    inv.UpdatedBy = CurrentSession.GetCurrentSession().UserName;
                    inv.ProductionOut+= qty;
                    inv.BalanceQty = inv.BalanceQty - qty;
                    inventory.Update(inv, inv.Id);
                    stocks.Add(stock);
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