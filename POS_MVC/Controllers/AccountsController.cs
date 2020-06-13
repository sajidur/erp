using RexERP_MVC.BAL;
using System;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IncomeStatement()
        {
            return View();
        }
        public ActionResult TrailBalance()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetIncomeStatement(DateTime fromDate,DateTime toDate)
        {
            LedgerPostingService ledgerPosting = new LedgerPostingService();
            ledgerPosting.GetIncomeStatement(fromDate,toDate);
            return Json("");
        }
        [HttpGet]
        public ActionResult BalanceSheet(DateTime toDate)
        {
            LedgerPostingService ledgerPosting = new LedgerPostingService();
         //   ledgerPosting.GetIncomeStatement(fromDate, toDate);
            return Json("");
        }
        [HttpGet]
        public ActionResult TrailBalanceSheet(DateTime fromDate, DateTime toDate)
        {
            LedgerPostingService ledgerPosting = new LedgerPostingService();
            var res=ledgerPosting.TrailBalance(fromDate, toDate);
            return Json(res,JsonRequestBehavior.AllowGet);
        }
    }
}