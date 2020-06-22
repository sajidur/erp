using RexERP_MVC.Models;
using RexERP_MVC.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class InventoryService
    {
        DBService<Inventory> service = new DBService<Inventory>();
        DBService<InventoryTransaction> _inventoryTransactionService = new DBService<InventoryTransaction>();

        public List<Inventory> GetAllForSale()
        {
            return service.GetAll().ToList();
        }

        public List<Inventory> GetAll()
        {
            return service.GetAll(a => a.GoodsType == "1" || a.GoodsType == "3").ToList();
        }
        public List<Inventory> GetAll(List<int> Ids)
        {
            return service.GetAll(a => Ids.Contains(a.Id)).ToList();
        }
        public List<Inventory> GetAllPaddy()
        {
            return service.GetAll(a => a.GoodsType == "1").ToList();
        }

        public List<Inventory> GetAllPaddyFilteredBySupplier(int supplierId)
        {
            return service.GetAll(a => a.GoodsType == "1" && a.SupplierId == supplierId).ToList();
        }

        public List<Inventory> GetAllPaddyFilteredByWarehouse(int warehouseId)
        {
            return service.GetAll(a => a.GoodsType == "1" && a.WarehouseId == warehouseId).ToList();
        }

        public List<Inventory> GetAllRice()
        {
            return service.GetAll(a => a.GoodsType == "3").ToList();
        }

        public List<Inventory> GetAllRiceFilteredBySupplier(int supplierId)
        {
            return service.GetAll(a => a.GoodsType == "3" && a.SupplierId == supplierId).ToList();
        }

        public List<Inventory> GetAllRiceFilteredByWarehouse(int warehouseId)
        {
            return service.GetAll(a => a.GoodsType == "3" && a.WarehouseId == warehouseId).ToList();
        }

        public List<Inventory> GetAllInventory()
        {
            return service.GetAll().ToList();
        }
        public Inventory Update(Inventory inventory)
        {
            return service.Update(inventory,inventory.Id);
        }

        public List<Inventory> GetAllFinishGoodsFilteredBySupplier(int supplierId)
        {
            return service.GetAll(a => a.GoodsType == "2" && a.SupplierId == supplierId).ToList();
        }

        public List<Inventory> GetAllFinishGoodsFilteredByWarehouse(int warehouseId)
        {
            return service.GetAll(a => a.GoodsType == "2" && a.WarehouseId == warehouseId).ToList();
        }
 
        public Inventory GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public bool OpeningInventorySave(StockIn stockIn)
        {
            var balance = 0.0m;
            var existingItem = service.GetAll(a => a.ProductId == stockIn.ProductId && a.BrandId == stockIn.BrandId && a.SizeId == stockIn.SizeId && a.APIId==stockIn.APIId && a.IsActive == true && a.WarehouseId == stockIn.WarehouseId).ToList();
            if (existingItem.Count > 0)
            {
                foreach (var inv in existingItem)
                {
                    inv.UpdatedDate = DateTime.Now;
                    inv.UpdatedBy = "";
                    inv.BalanceQty = inv.BalanceQty + stockIn.BaleQty ?? 0;
                    inv.OpeningQty = inv.OpeningQty ?? 0 + stockIn.BaleQty ?? 0;
                    service.Update(inv, inv.Id);
                    balance = inv.BalanceQty;
                }

            }
            else
            {
                Inventory result = new Inventory();
                Inventory FinalResult = new Inventory();
                result.ProductId = (int)stockIn.ProductId;
                result.SupplierId = stockIn.SupplierId ?? 0;
                result.WarehouseId = (int)stockIn.WarehouseId;
                result.OpeningQty = stockIn.BaleQty;
                result.Costprice = stockIn.Rate;
                result.PurchasePrice = stockIn.Rate;
                result.BrandId = stockIn.BrandId;
                result.SizeId = stockIn.SizeId;
                result.APIId = stockIn.APIId;
                result.BalanceQty = stockIn.BaleQty ?? 0;
                result.Notes = stockIn.Notes;
                result.GoodsType = "2";
                result.CreatedBy = CurrentSession.GetCurrentSession().UserName;
                result.CreatedDate = DateTime.Now;
                result.IsActive = true;
                FinalResult = service.Save(result);
                balance = result.BalanceQty;
            }
            var invTransaction = new InventoryTransaction()
            {
                APIId = stockIn.APIId,
                BalanceQty = balance,
                BrandId = stockIn.BrandId,
                CreatedBy = CurrentSession.GetCurrentSession().UserName,
                CreatedDate = DateTime.Now,
                GoodsType = "Finished Goods",
                InventoryGuid = Guid.NewGuid().ToString(),
                InvoiceNo = stockIn.InvoiceNo,
                IsActive = true,
                ProductId = stockIn.ProductId ?? 0,
                PurchasePrice =stockIn.Rate,
                Qty = stockIn.BaleQty,
                SalesPrice = 0,
                SizeId = stockIn.SizeId,
                SupplierId = stockIn.SupplierId ?? 0,

                TransactionType = (int)Util.TransactionType.OpeningQty,
                WarehouseId = stockIn.WarehouseId ?? 0
            };
            _inventoryTransactionService.Save(invTransaction);
            return true;
        }
    }
}