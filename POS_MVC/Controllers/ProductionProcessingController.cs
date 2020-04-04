using RexERP_MVC.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System.Net;
using RexERP_MVC.Util;

namespace RexERP_MVC.Controllers
{
    public class ProductionProcessingController : Controller
    {
        // GET: ProductionProcessing
        StockOutService service = new StockOutService();
        private InventoryService inventoryService = new InventoryService();
        private ProductService productService = new ProductService();
        StockOutService stockOutService = new StockOutService();
        StockInService serviceStockIn = new StockInService();
        WareHouseService serviceWareHouseService = new WareHouseService();

        public ActionResult Index()
        {
            List<WareHouse> wareHouses = serviceWareHouseService.GetAll();
            return View(wareHouses);
        }

        public ActionResult StockOut()
        {
            return View(new StockOut());
        }
        public ActionResult StockOutReport()
        {
            return View();
        }

        public ActionResult GetAllInventory()
        {
            List<Inventory> inventories = inventoryService.GetAll();
            if (inventories == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<Inventory>, List<InventoryResponse>>(inventories);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetInvoiceNumber()
        {
            string invoiceNumber =
                new GlobalClass().GetMaxId("Id","StockOut");
            return Json(invoiceNumber, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetInvoiceNumberForStockIn()
        {
            string invoiceNumber =
                new GlobalClass().GetMaxId("Id", "StockIn");
            return Json(invoiceNumber, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(string InvoiceNo, string Notes, List<StockOutRequest> stockOuts)
        {
            var saved=service.Save(stockOuts, InvoiceNo, Notes);
            return Json(saved, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveStockIn(string InvoiceNo, string Notes, List<StockIn> stockIns)
        {
            StockIn result = new StockIn();
            //if (ModelState.IsValid)
            {
                foreach (var item in stockIns)
                {
                    item.Notes = Notes;
                    item.InvoiceNo = InvoiceNo;
                    serviceStockIn.Save(item);
                }
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InventoryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = inventoryService.GetById(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<Inventory, InventoryResponse>(inventory);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductForStockIn()
        {
            List<Product> products = productService.GetAllProductForStockIn();
            if (products == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<Product>, List<ProductResponse>>(products);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetAllStockOut()
        {
            List<StockOut> products = stockOutService.GetAll();
            if (products == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<StockOut>, List<StockOutResponse>>(products);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllStockOutChallanList()
        {
            List<string> products = stockOutService.GetAllStockChallan();
            if (products == null)
            {
                return HttpNotFound();
            }
           // var result = AutoMapper.Mapper.Map<List<StockOut>, List<StockOutResponse>>(products);
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}