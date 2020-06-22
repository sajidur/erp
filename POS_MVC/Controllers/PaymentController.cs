using RexERP_MVC.BAL;
using RexERP_MVC.BLL;
using RexERP_MVC.Models;
using RexERP_MVC.RequestModel;
using RexERP_MVC.Util;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        PaymentService _paymentService = new PaymentService();
        AccountLedgerService ledgerService = new AccountLedgerService();
        LedgerPostingService postingService = new LedgerPostingService();
        PartyBalanceService partyBalanceService = new PartyBalanceService();
        SupplierService supplierService = new SupplierService();
        CustomerService customerService = new CustomerService();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Transfer()
        {
            return View();
        }

        public ActionResult PendingPayment()
        {
            return View();
        }
        public ActionResult GetAllPendingPayment()
        {
            var pendingPayment = _paymentService.GetAllPendingPayment();
            var res = AutoMapper.Mapper.Map<List<PaymentMasterResponse>>(pendingPayment);
            return Json(res,JsonRequestBehavior.AllowGet);
        }
        public ActionResult PaymentSave(string voucherNo, int ledgerId, DateTime voucherDate, string notes, List<LedgerPosting> ledgerPosting, bool isSendSMS)
        {
            decimal? credit;
            //var supplierInfo = supplierService.GetById(supplierId);
            //if (supplierInfo == null)
            //{
            //    return Json("error", JsonRequestBehavior.AllowGet);
            //}
            var paymentReciveMaster = new PaymentMaster() {
                CreatedDate = DateTime.Now,
                Extra1 = ledgerPosting.Select(a => a.Credit).Sum().ToString(),
                InvoiceNo=voucherNo,
                VoucherNo=voucherNo,
                VoucherTypeId=(int)VoucherTypeEnum.PaymentVoucher,
                TotalAmount=ledgerPosting.Select(a=>a.Debit).Sum(),
                IsApproved=false,
                CreatedBy=CurrentSession.GetCurrentSession().UserName,
                LedgerDate=voucherDate,
                LedgerId= ledgerId,
                Narration=notes
            };
            foreach (var item in ledgerPosting)
            {
                var paymentDetails = new PaymentDetail()
                {
                    Amount = item.Debit,
                    ChequeNo = item.ChequeNo,
                    ChequeDate = item.ChequeDate,
                    LedgerId = item.LedgerId,
                    CreatedDate = DateTime.Now,
                    CreatedBy = CurrentSession.GetCurrentSession().UserId,
                    Extra1=notes
                };
                paymentReciveMaster.PaymentDetails.Add(paymentDetails);
            }
            _paymentService.SavePayment(paymentReciveMaster);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteTempPayment(int Id)
        {
            try
            {
                var payment =AutoMapper.Mapper.Map<PaymentMasterResponse>(_paymentService.GetPaymentById(Id));
                _paymentService.DeletePayment(payment);
                return Json("Sucess", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Failed:"+ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Authorize(PaymentAuthorizationRequest request)
        {
            var payment = _paymentService.GetPaymentById(request.Id);
            if (payment==null)
            {
                return Json("Failed:Payment not found to authorized!!" , JsonRequestBehavior.AllowGet);
            }
            decimal? credit;
            //credit
            foreach (var details in payment.PaymentDetails)
            {
                var item = new LedgerPosting();
                item.LedgerId = details.LedgerId;
                item.CreatedBy = CurrentSession.GetCurrentSession().UserId;
                item.Credit = 0;
                item.Debit = request.Amount;
                item.InvoiceNo = payment.InvoiceNo;
                item.VoucherNo = payment.VoucherNo;
                item.PostingDate = payment.LedgerDate;
                item.ChequeDate = details.ChequeDate;
                item.ChequeNo = details.ChequeNo;
                item.VoucherTypeId = payment.VoucherTypeId;
                item.Extra1 = "Voucher:" + payment.VoucherNo + " " + payment.Narration + "|" + request.Notes;
                postingService.Save(item);
                break;
            }
            //debit
            LedgerPosting posting = new LedgerPosting();
            posting.ChequeDate = DateTime.Now;
            posting.VoucherNo = payment.VoucherNo;
            posting.ChequeNo = "";
            posting.VoucherTypeId = (int)BAL.VoucherTypeEnum.PaymentVoucher;
            posting.LedgerId = payment.LedgerId;
            posting.PostingDate = payment.LedgerDate;
            posting.Credit =request.Amount;
            posting.Debit = 0;
            posting.Extra1 = "Voucher:" + payment.VoucherNo + " " +request.Notes;
            postingService.Save(posting);
            //balance
            //party balance 
            PartyBalance balance = new PartyBalance();
            balance.AgainstVoucherTypeId = 4;
            balance.VoucherNo = payment.VoucherNo;
            balance.PostingDate = payment.LedgerDate;
            balance.LedgerId = payment.LedgerId ?? 0;
            balance.Debit = request.Amount;
            balance.Credit = 0;
            balance.VoucherTypeId = (int)BAL.VoucherTypeEnum.PaymentVoucher;
            balance.extra1 = "Payment Invoice: " + payment.VoucherNo + " Notes:" + request.Notes;
            balance.extra2 = posting.Id.ToString();

            partyBalanceService.Save(balance);

            //isSendSMS = false;
            //if (isSendSMS)
            //{
            //    SMSEmailService sMSEmailService = new SMSEmailService();
            //    string phone = supplierInfo.Phone;
            //    rptIndividualLedger_Result due = customerService.GetBalance((supplierInfo.LedgerId ?? 0));

            //    string balanceText = "";
            //    credit = due.Balance;
            //    var num = new decimal();
            //    if ((credit.GetValueOrDefault() < num ? !credit.HasValue : true))
            //    {
            //        credit = due.Balance;
            //        balanceText = string.Concat("Your Present Balance With Dada Rice Tk=", string.Format("{0:#,#.}", decimal.Round((credit.HasValue ? credit.GetValueOrDefault() : decimal.Zero)), ""), "/=.");
            //    }
            //    else
            //    {
            //        decimal minusOne = decimal.MinusOne;
            //        credit = due.Balance;
            //        balanceText = string.Concat("Your Present Balance With Dada Rice Tk=", string.Format("{0:#,#.}", minusOne * decimal.Round((credit.HasValue ? credit.GetValueOrDefault() : decimal.Zero)), ""), "/= Thanks.");
            //    }
            //    balanceText = "";
            //    string[] name = new string[] { "Dear ", supplierInfo.Name, " Tk=", null, null, null };
            //    credit = balance.Credit;
            //    name[3] = string.Format("{0:#,#.}", decimal.Round((posting.Credit.HasValue ? posting.Credit.GetValueOrDefault() : decimal.Zero)), "");
            //    name[4] = "/- has been Deposited to your Account. Ref:No-" + voucherNo + ", Dated:" + voucherDate.ToString("dd-MM-yyyy") + ". Thanks with Dada Rice";
            //    sMSEmailService.SendOneToOneSingleSms("01979110321", string.Concat(string.Concat(name), balanceText), false);
            //}
            //updated au authorized
            payment.ApprovedBy = DateTime.Now;
            payment.ApprovedNotes = request.Notes;
            payment.IsApproved = true;
            _paymentService.Update(payment, payment.Id);
            foreach (var item in payment.PaymentDetails)
            {
                payment.ApprovedBy = DateTime.Now;
                payment.ApprovedNotes = request.Notes;
                payment.IsApproved = true;
                _paymentService.Update(item, item.Id);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public ActionResult ReceivePayment(string voucherNo, int supplierId, DateTime voucherDate, string notes, List<LedgerPosting> ledgerPosting,bool isSendSMS)
        {
            decimal? credit;
            var supplierInfo = supplierService.GetById(supplierId);
            if (supplierInfo == null)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            //credit
            foreach (var item in ledgerPosting)
            {
                item.Credit = 0;
                item.VoucherNo = voucherNo;
                item.PostingDate = voucherDate;
                item.ChequeDate = DateTime.Now;
                item.ChequeNo = "";
                item.VoucherTypeId =(int)BAL.VoucherTypeEnum.PaymentVoucher;
                item.Extra1 = "Voucher:" + voucherNo + " " + notes;
                postingService.Save(item);
            }
            //debit
            LedgerPosting posting = new LedgerPosting();
            posting.ChequeDate = DateTime.Now;
            posting.VoucherNo = voucherNo;
            posting.ChequeNo = "";
            posting.VoucherTypeId = (int)BAL.VoucherTypeEnum.PaymentVoucher;
            posting.LedgerId = supplierInfo.LedgerId;
            posting.PostingDate = voucherDate;
            posting.Credit = ledgerPosting.Sum(a => a.Debit).Value;
            posting.Debit = 0;
            posting.Extra1 = "Voucher:" + voucherNo + " " + notes;
            postingService.Save(posting);
            //balance
            //party balance 
            PartyBalance balance = new PartyBalance();
            balance.AgainstVoucherTypeId = 4;
            balance.VoucherNo = voucherNo;
            balance.PostingDate = voucherDate;
            balance.LedgerId = supplierInfo.LedgerId ?? 0;
            balance.Debit = posting.Credit;
            balance.Credit = 0;
            balance.VoucherTypeId =(int) BAL.VoucherTypeEnum.PaymentVoucher;
            balance.extra1 = "Payment Invoice: " + voucherNo + " Notes:" + notes;
            balance.extra2 = posting.Id.ToString();

            partyBalanceService.Save(balance);

            isSendSMS = false;
            if (isSendSMS)
            {
                SMSEmailService sMSEmailService = new SMSEmailService();
                string phone = supplierInfo.Phone;
                rptIndividualLedger_Result due = customerService.GetBalance((supplierInfo.LedgerId??0));

                string balanceText = "";
                credit = due.Balance;
                var num = new decimal();
                if ((credit.GetValueOrDefault() < num ? !credit.HasValue : true))
                {
                    credit = due.Balance;
                    balanceText = string.Concat("Your Present Balance With Dada Rice Tk=", string.Format("{0:#,#.}", decimal.Round((credit.HasValue ? credit.GetValueOrDefault() : decimal.Zero)), ""), "/=.");
                }
                else
                {
                    decimal minusOne = decimal.MinusOne;
                    credit = due.Balance;
                    balanceText = string.Concat("Your Present Balance With Dada Rice Tk=", string.Format("{0:#,#.}", minusOne * decimal.Round((credit.HasValue ? credit.GetValueOrDefault() : decimal.Zero)), ""), "/= Thanks.");
                }
                balanceText = "";
                string[] name = new string[] { "Dear ", supplierInfo.Name, " Tk=", null, null, null };
                credit = balance.Credit;
                name[3] = string.Format("{0:#,#.}", decimal.Round((posting.Credit.HasValue ? posting.Credit.GetValueOrDefault() : decimal.Zero)), "");
                name[4] = "/- has been Deposited to your Account. Ref:No-"+ voucherNo+", Dated:"+ voucherDate.ToString("dd-MM-yyyy")+". Thanks with Dada Rice";
                sMSEmailService.SendOneToOneSingleSms("01979110321", string.Concat(string.Concat(name), balanceText),false);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetInvoiceNumber()
        {
            string invoiceNumber = DateTime.Now.Year +
                new GlobalClass().GetMaxId("Id", "LedgerPosting");
            return Json(invoiceNumber, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllInvoice(string fromDate, string toDate)
        {
            var partybalance = partyBalanceService.DailyReceiveAndPayment(2,fromDate,toDate);
            return Json(partybalance, JsonRequestBehavior.AllowGet);
        }

    }
}