using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class SalaryItemNewController : Controller
    {
        private SalaryItemNewService db = new SalaryItemNewService();

       // private SalaryPackageService dbSP = new SalaryPackageService();

        // GET: SalaryItemNew
        //public ActionResult Index()
        //{
        //    return View(new SalaryItemNew());
        //}
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PayHead category, int create)
        {
            var result = category;
            if (ModelState.IsValid)
            {
                result = db.Save(category);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateFinally()
        {
            List<SalaryPackage> objList = new List<SalaryPackage>();
            List<PayHead> products = db.GetAll();
            if (products == null)
            {
                foreach (PayHead a in products)
                {
                    SalaryPackage obj = new SalaryPackage();
                  //  obj.SalaryPackageName = a.SalaryPackageName;
                  //  obj.TotalAmount = a.TotalAmount;
                  //  obj.Description = a.Description;
                    objList.Add(obj);
                }
            }

            var result = objList;

          //  result = dbSP.Save(objList);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetAll()
        {
            List<PayHead> products = db.GetAll();
            if (products == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<PayHead>, List<SalaryItemNewViewModel>>(products);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayHead product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<PayHead, SalaryItemNewViewModel>(product);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(PayHead model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayHead product = db.GetById(model.Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            //model.IsActive = true;
            //model.UpdateDate = DateTime.Now;
            //model.UpdateBy = CurrentSession.GetCurrentSession().UserName;
            db.Update(model, model.Id);
            return Json("Updated", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PayHead product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            // product.IsActive = false;
            db.Update(product, id ?? 0);
            //int delete = db.Delete(id ?? 0);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
    }
}