using AutoMapper;
using RexERP_MVC.BAL;
using RexERP_MVC.BLL;
using RexERP_MVC.Models;
using RexERP_MVC.RequestModel;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace RexERP_MVC.Controllers
{
    public class LedgerPostingController : Controller
    {
        // GET: LedgerPosting
        LedgerPostingService postingService = new LedgerPostingService();
        JournalPostingService journalPostingService = new JournalPostingService();
        PartyBalanceService partyBalanceService = new PartyBalanceService();

        AccountGroupService accountGroupService = new AccountGroupService();
        AccountLedgerService accledgerService = new AccountLedgerService();
        CustomerService customerService = new CustomerService();
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddExpense()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddIncome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contra()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Journal()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DayBook()
        {
            return View();
        }
        public ActionResult CashBook()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Withdraw()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CashBookReport(string fromDate, string toDate)
        {
            DateTime from = DateTime.Now.Date;
            DateTime to = DateTime.Now.Date;
            if (!string.IsNullOrEmpty(fromDate))
            {
                from = Convert.ToDateTime(fromDate).Date;
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                to = Convert.ToDateTime(toDate).Date;
            }
            List<CashBookResponse> result = this.postingService.GetCashBook(from, to);
            return base.Json(result, 0);
        }

        [HttpGet]
        public ActionResult DayBookReport(string fromDate, string toDate)
        {
            DateTime from = DateTime.Now.Date;
            DateTime to = DateTime.Now.Date;
            if (!string.IsNullOrEmpty(fromDate))
            {
                from = Convert.ToDateTime(fromDate).Date;
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                to = Convert.ToDateTime(toDate).Date;
            }
            var result = this.postingService.GetAll(from, to).OrderBy(a=>a.Id).ThenBy(a=>a.VoucherNo);
            var res = Mapper.Map<List<LedgerPostingResponse>>(result);
            return base.Json(res, 0);
        }

        public ActionResult GetIncomes(string fromDate, string toDate)
        {
            DateTime from = Convert.ToDateTime(fromDate);
            DateTime to = Convert.ToDateTime(toDate);
            List<JournalMaster> ledger = this.journalPostingService.GetAll(from, to);
            return base.Json(Mapper.Map<List<JournalMaster>, List<JournalMasterResponse>>(ledger), 0);
        }
        public ActionResult GetExpenses(string fromDate, string toDate)
        {
            DateTime from = Convert.ToDateTime(fromDate);
            DateTime to = Convert.ToDateTime(toDate);
            List<JournalMaster> ledger = this.journalPostingService.GetAll(from, to);
            return base.Json(Mapper.Map<List<JournalMaster>, List<JournalMasterResponse>>(ledger), 0);
        }

        [HttpGet]
        public ActionResult ExpenseList(string fromDate, string toDate)
        {
            DateTime from = Convert.ToDateTime(fromDate);
            DateTime to = Convert.ToDateTime(toDate);
            List<LedgerPosting> ledgerPosting = this.postingService.GetAll(from, to, 6) ?? new List<LedgerPosting>();
            return base.Json(Mapper.Map<List<LedgerPosting>, List<LedgerPostingResponse>>(ledgerPosting), 0);
        }

        public ActionResult GetInvoiceNumber()
        {
            string invoiceNumber = new GlobalClass().GetMaxId("Id", "JournalMaster");
            string xx = invoiceNumber.PadLeft(6, '0');
            return Json(xx, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditLedgerPosting(int ledgerPostingId)
        {
            var posting = postingService.GetById(ledgerPostingId);
            var allPosting = partyBalanceService.GetAll();
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public ActionResult ReceiptDelete(int id)
        {
            ActionResult actionResult;
            try
            {
                LedgerPosting postingObj = this.postingService.GetById(new int?(id));
                foreach (LedgerPosting item in this.postingService.GetAll(postingObj.VoucherNo, true))
                {
                    item.IsActive = false;
                    this.postingService.Update(item, item.Id);
                }
                PartyBalanceService partyBalanceService = this.partyBalanceService;
                int? ledgerId = postingObj.LedgerId;
                PartyBalance paymentObj = partyBalanceService.GetByVoucher((ledgerId.HasValue ? ledgerId.GetValueOrDefault() : 0), postingObj.VoucherNo);
                this.partyBalanceService.Delete(paymentObj.PartyBalanceId);
                AccountLedger customer = this.accledgerService.GetById(postingObj.LedgerId);
                CustomerService customerService = new CustomerService();
                ledgerId = postingObj.LedgerId;
                rptIndividualLedger_Result due = customerService.GetBalance((ledgerId.HasValue ? ledgerId.GetValueOrDefault() : 0));
                string balanceText = "";
                decimal? balance = due.Balance;
                decimal num = new decimal();
                if ((balance.GetValueOrDefault() < num ? !balance.HasValue : true))
                {
                    balance = due.Balance;
                    balanceText = string.Concat("Balance with Dada Rice Tk=", string.Format("{0:#,#.}", decimal.Round((balance.HasValue ? balance.GetValueOrDefault() : decimal.Zero)), ""), "=");
                }
                else
                {
                    decimal minusOne = decimal.MinusOne;
                    balance = due.Balance;
                    balanceText = string.Concat("Balance with Dada Rice Tk=", string.Format("{0:#,#.}", minusOne * decimal.Round((balance.HasValue ? balance.GetValueOrDefault() : decimal.Zero)), ""), "=");
                }
                var isSendSMS = false;
                if (isSendSMS)
                {
                    SMSEmailService sMSEmailService = new SMSEmailService();
                    string[] ledgerName = new string[] { "Dear ", customer.LedgerName, ",Tk=", null, null, null, null, null, null };
                    balance = postingObj.Debit;
                    ledgerName[3] = string.Format("{0:#,#.}", decimal.Round((balance.HasValue ? balance.GetValueOrDefault() : decimal.Zero)), "");
                    ledgerName[4] = "/- Received was wrong posted. Your Ref:No:";
                    ledgerName[5] = postingObj.VoucherNo;
                    ledgerName[6] = " has been deleted,";
                    ledgerName[7] = balanceText;
                    ledgerName[8] = " Dada Rice.";
                    sMSEmailService.SendOneToOneSingleSms("01739110321", string.Concat(ledgerName));
                }
                actionResult = base.Json("Sucess", 0);
            }
            catch (Exception exception)
            {
                actionResult = base.Json(exception.Message, 0);
            }
            return actionResult;
        }
        public ActionResult PaymentDelete(int id)
        {
            ActionResult actionResult;
            try
            {
                LedgerPosting postingObj = this.postingService.GetById(new int?(id));
                foreach (LedgerPosting item in this.postingService.GetAll(postingObj.VoucherNo, true))
                {
                    item.IsActive = false;
                    this.postingService.Update(item, item.Id);
                }
                PartyBalanceService partyBalanceService = this.partyBalanceService;
                int? ledgerId = postingObj.LedgerId;
                PartyBalance paymentObj = partyBalanceService.GetByVoucher((ledgerId.HasValue ? ledgerId.GetValueOrDefault() : 0), postingObj.VoucherNo);
                this.partyBalanceService.Delete(paymentObj.PartyBalanceId);
                AccountLedger customer = this.accledgerService.GetById(postingObj.LedgerId);
                CustomerService customerService = new CustomerService();
                ledgerId = postingObj.LedgerId;
                rptIndividualLedger_Result due = customerService.GetBalance((ledgerId.HasValue ? ledgerId.GetValueOrDefault() : 0));
                string balanceText = "";
                decimal? balance = due.Balance;
                decimal num = new decimal();
                if ((balance.GetValueOrDefault() < num ? !balance.HasValue : true))
                {
                    balance = due.Balance;
                    balanceText = string.Concat("Balance with Dada Rice Tk=", string.Format("{0:#,#.}", decimal.Round((balance.HasValue ? balance.GetValueOrDefault() : decimal.Zero)), ""), "=");
                }
                else
                {
                    decimal minusOne = decimal.MinusOne;
                    balance = due.Balance;
                    balanceText = string.Concat("Balance with Dada Rice Tk=", string.Format("{0:#,#.}", minusOne * decimal.Round((balance.HasValue ? balance.GetValueOrDefault() : decimal.Zero)), ""), "=");
                }
                var isSendSMS = false;
                if (isSendSMS)
                {
                    SMSEmailService sMSEmailService = new SMSEmailService();
                    string[] ledgerName = new string[] { "Dear ", customer.LedgerName, ",Tk=", null, null, null, null, null, null };
                    balance = postingObj.Credit;
                    ledgerName[3] = string.Format("{0:#,#.}", decimal.Round((balance.HasValue ? balance.GetValueOrDefault() : decimal.Zero)), "");
                    ledgerName[4] = " payment was wrong posted. Your Ref No:";
                    ledgerName[5] = postingObj.VoucherNo;
                    ledgerName[6] = " has been deleted,";
                    ledgerName[7] = balanceText;
                    ledgerName[8] = " Dada Rice.";
                    sMSEmailService.SendOneToOneSingleSms("01739110321", string.Concat(ledgerName));
                }
                actionResult = base.Json("Sucess", 0);
            }
            catch (Exception exception)
            {
                actionResult = base.Json(exception.Message, 0);
            }
            return actionResult;
        }
        [HttpGet]
        public ActionResult LedgerReport(DateTime fromDate, DateTime toDate)
        {
            var trailBalance = this.postingService.GetAllLedger(fromDate, toDate);
            return base.Json(trailBalance, 0);
        }
        [HttpGet]
        public ActionResult GetAllLedgerPosting(DateTime fromDate, DateTime toDate, int id, int VoucherTypeId)
        {
            List<LedgerPosting> ledgerPosting = this.postingService.GetAll(fromDate, toDate, id, VoucherTypeId) ?? new List<LedgerPosting>();
            return base.Json(Mapper.Map<List<LedgerPosting>, List<LedgerPostingResponse>>(ledgerPosting), 0);
        }
        [HttpGet]
        public ActionResult LedgerPostingByLedger(DateTime fromDate, DateTime toDate, int ledgerId)
        {
            List<LedgerPostingResponse> ledgerPosting = this.postingService.GetAllByLedger(fromDate,toDate,ledgerId);
            return base.Json(ledgerPosting,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GroupWiseLedgerReport(DateTime fromDate, DateTime toDate, int groupId)
        {
            List<LedgerPostingResponse> ledgerPosting = this.postingService.GetAllByGroup(fromDate, toDate,groupId);
            return base.Json(ledgerPosting,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetContraInvoiceNo()
        {
            string invoice = new GlobalClass().GetMaxId("Id", "LedgerPosting");
            string xx = "JO" + invoice.PadLeft(6, '0');
            return Json(xx, JsonRequestBehavior.AllowGet);
        }

    }
}