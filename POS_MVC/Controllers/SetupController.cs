using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class SetupController : Controller
    {
        // GET: Setup
        UnitService service = new UnitService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UnitSetup()
        {
            return View();
        }
        public ActionResult Units()
        {
            var units=  service.GetAll();
            return Json(units, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UnitSetup(Unit unit)
        {
            return View();
        }
    }
}