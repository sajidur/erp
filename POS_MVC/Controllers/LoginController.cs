using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class LoginController : Controller
    {
        LoginService service = new LoginService();
        CompanyService companyService = new CompanyService();
        FinancialYearService finService = new FinancialYearService();
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var msg = service.GetAll().Where(a => a.UserName == user.UserName && a.UserPassword == user.UserPassword).FirstOrDefault();

            if (msg!=null)
            {
                CreateSession(user.UserName);
                return RedirectToAction("index", "homepage");
            }
            else
            {
                Session["Session"] = null;
                ModelState.AddModelError("Not found","Not Found!!");
                return View("index");
            }
           // return Json(msg, JsonRequestBehavior.AllowGet);

        }
        
       
        private void CreateSession(string userName)
        {
            var data = service.GetAll().Where(a=>a.UserName==userName).FirstOrDefault();
            var company = companyService.GetAll().FirstOrDefault();
            AppSession appSession = new AppSession();
            if (data != null)
            {
                appSession.UserId = data.Id;
                appSession.UserName = data.UserName;
                appSession.UserRoleId = data.UserRoleId;
                appSession.UserStatus = data.UserStatus;
                appSession.BranchId = data.BranchId;
                appSession.FinancialYear = finService.GetAll().LastOrDefault().Id;
                appSession.Company = AutoMapper.Mapper.Map<CompanyResponse>(company);
                Session["Session"] = appSession;
            }
            else
            {
                Session["Session"] = null;
            }

        }

        public ActionResult GetRoleWiseScreen()
        {
            List<RoleWiseScreenPermission> screenList = service.GetRoleWiseService();
            return PartialView("_ScreenList", screenList);
        }


        public JsonResult ApproveScreen(string roleId, string ScreenId,string userName, string val)
        {
            var roleService = new RoleWiseScreenPermission
            {
                RoleId = roleId,
                ScreenId = ScreenId,
                UserName = userName,
                CompanyId = 1
            };
            var message = service.SaveRoleWisePermission(roleService);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Login");
        }
    }
}