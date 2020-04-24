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
    }
}