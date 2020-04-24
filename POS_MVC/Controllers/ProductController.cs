using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.RequestModel;
using RexERP_MVC.Util;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class ProductController : Controller
    {
        private ProductService db = new ProductService();
        private InventoryService _inventoryService = new InventoryService();


        // GET: /Category/
        public ActionResult Index()
        {

            ViewBag.Title = "Product";
            return View(new Product());
        }
        public ActionResult PriceSetup()
        {
            return View();
        }
        public ActionResult BestSelling()
        {

            ViewBag.Title = "Best Selling Product";
            return View(new Product());
        }
        // GET: /Category/Details/5
        public ActionResult GetAll(int type=0)
        {
            List<Product> products = db.GetAll(type);
            if (products == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<Product>, List<ProductResponse>>(products);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        // GET: /Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<Product, ProductResponse>(product);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Product category, int create)
        {
            var result = category;
            if (ModelState.IsValid)
            {
                category.CreatedDate = DateTime.Now;
                category.UpdateDate = DateTime.Now;
                category.CreatedBy = CurrentSession.GetCurrentSession().UserName;
                category.IsActive = true;
                result = db.Save(category);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PriceSetup(PriceSetupRequest request)
        {
            var inventory = _inventoryService.GetById(request.InventoryId);
            if (inventory!=null)
            {
                PriceSetup price = new PriceSetup() {InventoryId=inventory.Id,SalesPrice=request.SalesPrice,PurchasePrice=inventory.PurchasePrice,Active=true,CreatedDate=DateTime.Now,CreatedBy=CurrentSession.GetCurrentSession().UserName };
                db.SavePrice(price);
                inventory.SalesPrice = request.SalesPrice;
                _inventoryService.Update(inventory);
            }
            return Json("Saved Sucess!!", JsonRequestBehavior.AllowGet);
        }
        // GET: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.GetById(model.Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            model.IsActive = true;
            model.UpdateDate = DateTime.Now;
            model.UpdateBy = CurrentSession.GetCurrentSession().UserName;
            db.Update(model, model.Id);
            return Json("Updated", JsonRequestBehavior.AllowGet);
            //return View();
        }

        // GET: /Category/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            product.IsActive = false;
            db.Update(product, id ?? 0);
            //int delete = db.Delete(id ?? 0);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
    }
}