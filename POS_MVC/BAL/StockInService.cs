using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RexERP_MVC.Models;
using RexERP_MVC.Util;

namespace RexERP_MVC.BAL
{
    public class StockInService
    {
        DBService<StockIn> service = new DBService<StockIn>();
        DBService<Inventory> inventory = new DBService<Inventory>();

        public List<StockIn> GetAll()
        {
            return service.GetAll();
        }

        public StockIn GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public StockIn Save(StockIn stockIn)
        {
            var existingItem = inventory.GetAll(a => a.ProductId == stockIn.ProductId && a.BrandId==stockIn.BrandId && a.SizeId==stockIn.SizeId && a.IsActive == true && a.WarehouseId == stockIn.WarehouseId).ToList();
            if (existingItem.Count > 0)
            {
                foreach (var inv in existingItem)
                {
                    inv.UpdatedDate = DateTime.Now;
                    inv.UpdatedBy = "";
                    inv.BalanceQty = inv.BalanceQty + stockIn.BaleQty??0;
                    inv.ProductionIn = inv.ProductionIn ?? 0 + stockIn.BaleQty ?? 0;
                    inventory.Update(inv, inv.Id);
                }

            }
            else
            {
                Inventory result = new Inventory();
                Inventory FinalResult = new Inventory();

                result.ProductId = (int)stockIn.ProductId;
                result.SupplierId = stockIn.SupplierId??0;
                result.WarehouseId = (int)stockIn.WarehouseId;
                result.ProductionIn = stockIn.BaleQty;
                result.BrandId = stockIn.BrandId;
                result.SizeId = stockIn.SizeId;
                result.BalanceQty = stockIn.BaleQty??0;
                result.Notes = stockIn.Notes;
                result.GoodsType = "2";
                result.CreatedBy = CurrentSession.GetCurrentSession().UserName;
                result.CreatedDate = DateTime.Now;
                result.IsActive = true;
                FinalResult = inventory.Save(result);

            }
            return service.Save(stockIn);
        }


        public StockIn Update(StockIn t, int id)
        {
            return service.Update(t, id);

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}