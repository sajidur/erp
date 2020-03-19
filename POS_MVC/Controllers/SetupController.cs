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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UnitSetup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnitSetup(Unit unit)
        {
            return View();
        }
    }
}