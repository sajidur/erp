using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.RequestModel;
using RexERP_MVC.Util;
using System;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class SalaryPaymentController : Controller
    {
        // GET: SalaryPayment
        BonusDeductionService service = new BonusDeductionService();
        DBService<SalaryProcess> _salaryProcess = new DBService<SalaryProcess>();
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
            var bonusDeduction = new BonusDeduction()
            {
                BonusAmount = request.ÀdditionAmount,
                DeductionAmount=request.DeductionAmount,
                Date=request.Date,
                EmployeeId=request.EmployeeId,
                Month=request.Month,
                Year=request.Year,
                Narration=request.Notes,
                CreatedBy=CurrentSession.GetCurrentSession().UserId,
                CreatedDate=DateTime.Now
            };
            var res=service.Save(bonusDeduction);
            
            return Json(res.Id,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult PaySlip(int Id)
        {
           // var res = _salaryProcess.(bonusDeduction);
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}