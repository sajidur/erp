using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.RequestModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class JournalController : Controller
    {
        LedgerPostingService postingService = new LedgerPostingService();
        JournalPostingService journalPostingService = new JournalPostingService();

        // GET: Journal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JournalSave(string voucherNo, DateTime voucherDate, string notes, List<JournalRequest> ledgerPosting)
        {
            JournalMaster jmaster = new JournalMaster();
            jmaster.InvoiceNo = voucherNo;
            jmaster.LadgerDate = voucherDate;
            jmaster.Narration = notes;
            jmaster.TotalAmount = ledgerPosting.Where(a=>a.DrOrCr=="Dr").Sum(a=>a.Amount);
            journalPostingService.Save(jmaster);

            foreach (var item in ledgerPosting)
            {
                JournalDetail jdetails = new JournalDetail();

                jdetails.LedgerId = item.LedgerId;
                jdetails.ChequeNo = item.ChequeNo;

                //ledger posting
                LedgerPosting ledgersave = new LedgerPosting();
                ledgersave.VoucherTypeId = (int)BAL.VoucherType.JournalVoucher;
                ledgersave.VoucherNo = voucherNo;
                ledgersave.LedgerId = item.LedgerId;
                int a = ledgersave.LedgerId ?? 0;
                if (item.DrOrCr == "Dr")
                {
                    ledgersave.Debit = item.Amount;
                    ledgersave.Credit = 0;
                    jdetails.Debit = item.Amount;

                }
                else
                {
                    ledgersave.Credit = item.Amount;
                    ledgersave.Debit = 0;
                    jdetails.Credit = item.Amount;

                }
                ledgersave.InvoiceNo = voucherNo;
                ledgersave.ChequeNo = item.ChequeNo;
                ledgersave.PostingDate = Convert.ToDateTime(voucherDate);
                if (!string.IsNullOrEmpty(item.ChequeDate))
                {
                    ledgersave.ChequeDate = Convert.ToDateTime(item.ChequeDate);
                    jdetails.ChequeDate = Convert.ToDateTime(item.ChequeDate);

                }
                postingService.Save(ledgersave);
                journalPostingService.Save(jdetails);

            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddIncomeJournalSave(string voucherNo, int CostHeadId, DateTime voucherDate, string notes, List<JournalDetail> journalDetails, decimal TotalAmount, string ChkNo)
        {
            JournalMaster jmaster = new JournalMaster();

            jmaster.InvoiceNo = voucherNo;
            jmaster.LadgerDate = voucherDate;
            jmaster.Narration = notes;
            jmaster.TotalAmount = TotalAmount;
            journalPostingService.Save(jmaster);        
            foreach (var item in journalDetails)
            {
                JournalDetail jdetails = new JournalDetail();
                jdetails.LedgerId = item.LedgerId;
                jdetails.Credit = item.Credit;
                jdetails.Debit = item.Debit;
                jdetails.ChequeNo = item.ChequeNo;
                jdetails.ChequeDate = item.ChequeDate;
                journalPostingService.Save(jdetails);

            }

            //credit
            foreach (var item in journalDetails)
            {
                LedgerPosting lposting = new LedgerPosting();
                lposting.Credit = 0;
                lposting.VoucherNo = voucherNo;
                lposting.LedgerId = item.LedgerId;
                lposting.Debit = item.Debit ?? 0 + item.Credit ?? 0;
                lposting.PostingDate = voucherDate;
                lposting.ChequeDate = DateTime.Now;
                lposting.ChequeNo = "";
                lposting.VoucherTypeId = 4;
                lposting.Extra1 = "Voucher:" + voucherNo + " " + notes;
                postingService.Save(lposting);
            }
            //debit
            LedgerPosting posting = new LedgerPosting();
            posting.ChequeDate = DateTime.Now;
            posting.VoucherNo = voucherNo;
            posting.ChequeNo = "";
            posting.VoucherTypeId = 4;
            posting.LedgerId = CostHeadId;
            posting.PostingDate = voucherDate;
            posting.Credit = TotalAmount;
            posting.Debit = 0;
            posting.Extra1 = "Voucher:" + voucherNo + " " + notes;
            postingService.Save(posting);

            return Json("", JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddExpenseJournalSave(string voucherNo, int CostHeadId, DateTime voucherDate, string notes, List<JournalDetail> journalDetails, decimal TotalAmount, string ChkNo)
        {
            JournalMaster jmaster = new JournalMaster();
            JournalDetail jd = new JournalDetail();

            jmaster.InvoiceNo = voucherNo;
            jmaster.LadgerDate = voucherDate;
            jmaster.Narration = notes;
            jmaster.TotalAmount = TotalAmount;
            journalPostingService.Save(jmaster);

            jd.LedgerId = CostHeadId;
            jd.Credit = TotalAmount;
            jd.Credit = 0;
            jd.ChequeNo = ChkNo;
            jd.ChequeDate = voucherDate;
            journalPostingService.Save(jd);
            foreach (var item in journalDetails)
            {
                JournalDetail jdetails = new JournalDetail();

                jdetails.LedgerId = item.LedgerId;
                jdetails.Credit = 0;
                jdetails.Debit = item.Credit;
                jdetails.ChequeNo = "";
                jdetails.ChequeDate = voucherDate;
                journalPostingService.Save(jdetails);

            }

            //credit
            foreach (var item in journalDetails)
            {
                LedgerPosting lposting = new LedgerPosting();
                lposting.Credit = item.Debit ?? 0 + item.Credit ?? 0; ;
                lposting.VoucherNo = voucherNo;
                lposting.LedgerId = item.LedgerId;
                lposting.Debit = 0;
                lposting.PostingDate = voucherDate;
                lposting.ChequeDate = DateTime.Now;
                lposting.ChequeNo = "";
                lposting.VoucherTypeId = 4;
                lposting.Extra1 = "Voucher:" + voucherNo + " " + notes;
                postingService.Save(lposting);
            }
            //debit
            LedgerPosting posting = new LedgerPosting();
            posting.ChequeDate = DateTime.Now;
            posting.VoucherNo = voucherNo;
            posting.ChequeNo = "";
            posting.VoucherTypeId = 4;
            posting.LedgerId = CostHeadId;
            posting.PostingDate = voucherDate;
            posting.Credit = 0;
            posting.Debit = TotalAmount;
            posting.Extra1 = "Voucher:" + voucherNo + " " + notes;
            postingService.Save(posting);

            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}