﻿using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.Util;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class InventoryController : Controller
    { // GET: Brand
        InventoryService service = new InventoryService();

        public ActionResult Index()
        {
            ViewBag.Title = "Inventory";
            return View(new InventoryResponse());
        }
        // GET: /Category/Details/5
        public ActionResult GetAll()
        {
            List<Inventory> inventorys = service.GetAll();
            if (inventorys == null)
            {
                return HttpNotFound();
            }
            List<InventoryResponse> inventoryList = new List<InventoryResponse>();
            foreach (var item in inventorys)
            {
                var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(item);
                result.BalanceQtyInKG = item.BalanceQty;
                inventoryList.Add(result);
            }
            return Json(inventoryList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OpeningInventory(string InvoiceNo, string Notes, List<StockIn> stockIns)
        {
            foreach (var item in stockIns)
            {
                item.InvoiceNo = InvoiceNo;
                service.OpeningInventorySave(item);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PaddyReport()
        {
            return View();
        }

        public ActionResult GetAllPaddy()
        {
            List<Inventory> inventories = service.GetAllPaddy();
            if (inventories == null)
            {
                return HttpNotFound();
            }
            List<InventoryResponse> inventoryList = new List<InventoryResponse>();
            foreach (var item in inventories)
            {
                var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(item);
                result.BalanceQtyInKG = item.BalanceQty;
                inventoryList.Add(result);
            }
          //  var result = AutoMapper.Mapper.Map<List<Inventory>, List<InventoryResponse>>(inventories);
            return Json(inventoryList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllPaddyFilteredBySupplier(int id)
        {
            List<Inventory> inventories = service.GetAllPaddyFilteredBySupplier(id);
            if (inventories == null)
            {
                return HttpNotFound();
            }
            List<InventoryResponse> inventoryList = new List<InventoryResponse>();
            foreach (var item in inventories)
            {
                var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(item);
                result.BalanceQtyInKG = item.BalanceQty;
                inventoryList.Add(result);
            }
            return Json(inventoryList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllPaddyFilteredByWarehouse(int id)
        {
            List<Inventory> inventories = service.GetAllPaddyFilteredByWarehouse(id);
            if (inventories == null)
            {
                return HttpNotFound();
            }
            List<InventoryResponse> inventoryList = new List<InventoryResponse>();
            foreach (var item in inventories)
            {
                var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(item);
                result.BalanceQtyInKG = item.BalanceQty;
                inventoryList.Add(result);
            }
            return Json(inventoryList, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult RiceReport()
        //{
        //    return View();
        //}

        //public ActionResult GetAllRice()
        //{
        //    List<Inventory> inventories = service.GetAllRice();
        //    if (inventories == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    List<InventoryResponse> inventoryList = new List<InventoryResponse>();
        //    foreach (var item in inventories)
        //    {
        //        var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(item);
        //        result.BalanceQtyInKG = item.BalanceQty;
        //        inventoryList.Add(result);
        //    }
        //    return Json(inventoryList, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetAllRiceFilteredBySupplier(int id)
        {
            List<Inventory> inventories = service.GetAllRiceFilteredBySupplier(id);
            if (inventories == null)
            {
                return HttpNotFound();
            }
            List<InventoryResponse> inventoryList = new List<InventoryResponse>();
            foreach (var item in inventories)
            {
                var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(item);
                result.BalanceQtyInKG = item.BalanceQty;
                inventoryList.Add(result);
            }
            return Json(inventoryList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllRiceFilteredByWarehouse(int id)
        {
            List<Inventory> inventories = service.GetAllRiceFilteredByWarehouse(id);
            if (inventories == null)
            {
                return HttpNotFound();
            }
            List<InventoryResponse> inventoryList = new List<InventoryResponse>();
            foreach (var item in inventories)
            {
                var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(item);
                result.BalanceQtyInKG = item.BalanceQty;
                inventoryList.Add(result);
            }
            return Json(inventoryList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FinishGoodsReport()
        {
            return View();
        }

        public ActionResult GetAllInventory()
        {
            List<Inventory> inventories = service.GetAllInventory();
            if (inventories == null)
            {
                return HttpNotFound();
            }
            List<InventoryResponse> inventoryList = new List<InventoryResponse>();
            foreach (var item in inventories)
            {
                var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(item);
                result.BalanceQtyInKG = item.BalanceQty;
                inventoryList.Add(result);
            }
            return Json(inventoryList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllFinishGoodsFilteredBySupplier(int id)
        {
            List<Inventory> inventories = service.GetAllFinishGoodsFilteredBySupplier(id);
            if (inventories == null)
            {
                return HttpNotFound();
            }
            List<InventoryResponse> inventoryList = new List<InventoryResponse>();
            foreach (var item in inventories)
            {
                var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(item);
                result.BalanceQtyInKG = item.BalanceQty;
                inventoryList.Add(result);
            }
            return Json(inventoryList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllFinishGoodsFilteredByWarehouse(int id)
        {
            List<Inventory> inventories = service.GetAllFinishGoodsFilteredByWarehouse(id);
            if (inventories == null)
            {
                return HttpNotFound();
            }
            List<InventoryResponse> inventoryList = new List<InventoryResponse>();
            foreach (var item in inventories)
            {
                var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(item);
                result.BalanceQtyInKG = item.BalanceQty;
                inventoryList.Add(result);
            }
            return Json(inventoryList, JsonRequestBehavior.AllowGet);
        }

    }
}
