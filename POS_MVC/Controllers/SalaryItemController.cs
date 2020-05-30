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
    public class SalaryItemController : Controller
    {
        private SalaryItemService db = new SalaryItemService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Package()
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
        public ActionResult SalaryPackage(SalaryPackage salaryPackage)
        {
            var result = salaryPackage;
            if (ModelState.IsValid)
            {
                salaryPackage.TotalAmount = salaryPackage.SalaryPackageDetails.Sum(a => a.Amount);
                result = db.PackageSave(salaryPackage);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetAll()
        {
            List<PayHeadViewModel> products = db.GetAll();
            if (products == null)
            {
                return HttpNotFound();
            }
            return Json(products, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetAllPackage()
        {
            List<SalaryPackageResponse> products = db.GetAllPackage();
            if (products == null)
            {
                return HttpNotFound();
            }
            return Json(products, JsonRequestBehavior.AllowGet);

        }
    }
}