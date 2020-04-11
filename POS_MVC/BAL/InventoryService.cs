using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RexERP_MVC.BAL
{
    public class InventoryService
    {
        DBService<Inventory> service = new DBService<Inventory>();

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
    }
}