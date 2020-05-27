using RexERP_MVC.RequestModel;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class SalaryPaymentController : Controller
    {
        // GET: SalaryPayment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BonusDeduction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BonusDeduction(BonusDeductionRequest request)
        {
            return Json("",JsonRequestBehavior.AllowGet);
        }
    }
}