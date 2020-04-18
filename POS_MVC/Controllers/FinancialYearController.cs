using RexERP_MVC.BAL;
using RexERP_MVC.Util;
using RexERP_MVC.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class FinancialYearController : Controller
    {
        FinancialYearService year = new FinancialYearService();
        // GET: FinancialYear
        public ActionResult Index()
        {
            var categories =year.GetAll().ToList();
            var financialyear = CurrentSession.GetCurrentSession();
            var model = new FinancialYearView
            {
                SelectedYearId = financialyear.FinancialYear,
                FinancialYears = categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Extra1
                })
            };
            return PartialView("_FinancialYear", model);
        }

        public ActionResult ChangeFinancialYear(int newYearId)
        {
            var newSession= CurrentSession.GetCurrentSession();
            newSession.FinancialYear = newYearId;
            Session["Session"] = newSession;
            return Json("CHanged to"+newYearId, JsonRequestBehavior.AllowGet);
        }
    }
}