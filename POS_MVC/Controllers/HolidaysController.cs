using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class HolidaysController : Controller
    {
        HolidayService service = new HolidayService();
        public ActionResult Holiday()
        {
            return View("HolidaysSetup");
        }
        public ActionResult GetAll()
        {
            List<HOLIDAY> category = service.GetAll();
            if (category == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<HOLIDAY>, List<HoliDayResponse>>(category);
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(HOLIDAY category, int create)
        {
            var result = 0;
            if (ModelState.IsValid)
            {
                service.Save(category);
                return RedirectToAction("HolidaysSetup");
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}