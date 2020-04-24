using RexERP_MVC.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private StockOutService service = new StockOutService();
        private InventoryService inventoryService = new InventoryService();
        private ProductService productService = new ProductService();
        private StockOutService stockOutService = new StockOutService();
        private StockInService serviceStockIn = new StockInService();
        private WareHouseService serviceWareHouseService = new WareHouseService();
        private BrandService _brandService = new BrandService();
        private SizeService _sizeService = new SizeService();

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
            var brands =_brandService.GetAll();
            var sizes =_sizeService.GetAll();
            var stockOutInvoice = "";

                foreach (var item in stockIns)
                {
                    var brand = brands.Where(a => a.Id == item.BrandId).FirstOrDefault();
                    var size = sizes.Where(a => a.Id == item.SizeId).FirstOrDefault();
                    item.Notes = Notes;
                    item.InvoiceNo = InvoiceNo;
                    item.BrandName = brand.BrandName;
                    item.SizeName = size.Name;
                    item.CreatedDate = DateTime.Now;
                    item.CreatedBy = CurrentSession.GetCurrentSession().UserName;
                    if (!item.ProductionDate.HasValue)
                    {
                        item.ProductionDate = DateTime.Now;
                    }
                    serviceStockIn.Save(item);
                stockOutInvoice = item.StockOutInvoiceNo;
                }
                //stocOut Invoice Update
                var stockOuts = stockOutService.GetStockChallan(stockOutInvoice);
                foreach (var item in stockOuts)
                {
                    item.AlreadyProcessed = true;
                    item.UpdatedDate = DateTime.Now;
                    item.UpdatedBy = CurrentSession.GetCurrentSession().UserName;
                    stockOutService.Update(item, item.Id);
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