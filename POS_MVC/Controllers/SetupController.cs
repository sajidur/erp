using RexERP_MVC.BAL;
using RexERP_MVC.Models;
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
            if (string.IsNullOrEmpty(unit.Name))
            {
                return PartialView();
            }
            service.Save(unit);
            RedirectToAction("Index", "Product");
            return View("~/Views/Product/Index.cshtml");
        }
    }
}