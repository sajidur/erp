﻿using AutoMapper;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RexERP_MVC.Controllers
{
    public class ReportController : Controller
    {
        private SupplierService supplierService = new SupplierService();
        private PartyBalanceService partyBalanceService = new PartyBalanceService();
        private LedgerPostingService postingService = new LedgerPostingService();
        private SalesService salesService = new SalesService();

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeadOfficeInventoryReport()
        {
            return View();
        }

        public ActionResult DailyTransaction()
        {
            return View();
        }
        public ActionResult AgeingReportReceivable()
        {
            return View();
        }

        public ActionResult AgeingReportReceivableStatement(DateTime fromDate, DateTime toDate)
        {
            var data = partyBalanceService.AgeingReportSummary(fromDate,toDate);
            if (data == null)
            {
                return HttpNotFound();
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllInvoice(string fromDate, string toDate)
        {
            DateTime cFromDate = Convert.ToDateTime(fromDate).Date;
            DateTime cToDate = Convert.ToDateTime(toDate).Date;
            var partybalance =
                from a in this.postingService.GetAll(cFromDate, cToDate)
                select new { LedgerName = a.AccountLedger.LedgerName, Value = a.PostingDate.Value, Debit = a.Debit, Credit = a.Credit, VoucherNo = a.VoucherNo, Extra1 = a.Extra1, LedgerId = a.LedgerId };
            var jsonvalue= Json(partybalance,JsonRequestBehavior.AllowGet);
            jsonvalue.MaxJsonLength = int.MaxValue;
            return jsonvalue;
        }
        public ActionResult GetTruckRentReport(string fromDate, string toDate)
        {
            ActionResult actionResult;
            DateTime cFromDate = Convert.ToDateTime(fromDate).Date;
            DateTime cToDate = Convert.ToDateTime(toDate).Date;
            List<SalesMaster> category = null;
            category = salesService.GetAll(cFromDate, cToDate);

            if (category != null)
            {
                actionResult = base.Json(Mapper.Map<List<SalesMaster>, List<SalesMasterResponse>>(category), 0);
            }
            else
            {
                actionResult = base.HttpNotFound();
            }
            return actionResult;
        }
    }
}