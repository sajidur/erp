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
    public class APISetupController : Controller
    {
        // GET: APISetup
        private DBService<API> dBService = new DBService<API>();
        public ActionResult GetAll()
        {
            var all = dBService.GetAll();
            var res = AutoMapper.Mapper.Map<List<APIResponse>>(all);
            return Json(res,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(API model)
        {
            if (string.IsNullOrEmpty(model.APIName))
            {
                return View(new API());
            }
            model.Active = true;
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = "sajid";
            var saved=dBService.Save(model);
            return View(saved);
        }
        public ActionResult List()
        {
            var all = dBService.GetAll();
            var res = AutoMapper.Mapper.Map<List<APIResponse>>(all);
            return View(res);
        }
    }
}