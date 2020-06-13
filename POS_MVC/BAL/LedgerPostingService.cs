﻿using RexERP_MVC.Models;
using RexERP_MVC.Util;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class LedgerPostingService
    {
        DBService<LedgerPosting> service = new DBService<LedgerPosting>();
        DBService<AdditionalCost> addCostService = new DBService<AdditionalCost>();
        AccountLedgerService ledgerService = new AccountLedgerService();
        private DBService<CashBookResponse> cashBookService = new DBService<CashBookResponse>();
        FinancialYearService financialYearService = new FinancialYearService();
        private DBService<AccountGroup> _AccountsService = new DBService<AccountGroup>();
        public List<LedgerPosting> GetAll()
        {
            return service.GetAll().ToList();
        }
        public List<LedgerPosting> GetByVoucherNo(string voucherNo)
        {
            return service.GetAll(a=>a.VoucherNo==voucherNo && a.IsActive==true).ToList();
        }
        public List<CashBookResponse> GetCashBook(DateTime fromDate, DateTime toDate)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter param1 = new SqlParameter("@fromDate", SqlDbType.Date)
            {
                Value = fromDate
            };
            parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@toDate", SqlDbType.Date)
            {
                Value = toDate
            };
            parameters.Add(param2);
            return this.cashBookService.ExecuteProcedure(string.Concat(new object[] { "Exec CashBook '", fromDate, "','", toDate, "'" }), parameters);
        }

        public decimal GetTodayPayment(DateTime clientDate)
        {
            var payment= service.GetAll(a=>(a.VoucherTypeId==4 ||a.VoucherTypeId==29) && EntityFunctions.TruncateTime(a.PostingDate) == clientDate.Date).ToList();
            var totalcredit = payment.Where(a=>a.VoucherTypeId==4).Sum(a=>a.Credit).Value;
            var totaldebit = payment.Where(a => a.VoucherTypeId == 29).Sum(a => a.Debit).Value;
            return totalcredit - totaldebit;

        }
        public decimal GetTodayReceipt(DateTime clientDate)
        {
            var payment = service.GetAll(a => (a.VoucherTypeId == 5 || a.VoucherTypeId == 30) && EntityFunctions.TruncateTime(a.PostingDate) == clientDate.Date).ToList();
            var totalcredit = payment.Where(a => a.VoucherTypeId == 30).Sum(a => a.Credit).Value;
            var totaldebit = payment.Where(a => a.VoucherTypeId == 5).Sum(a => a.Debit).Value;
            return totaldebit-totalcredit;

        }
        public List<LedgerPosting> GetAll(string VoucherNo, bool returnAll)
        {
            List<LedgerPosting> list = this.service.GetAll((LedgerPosting a) => a.VoucherNo == VoucherNo && a.IsActive).ToList<LedgerPosting>();
            return list;
        }
        public List<LedgerPosting> GetAllByInvoice(string InvoiceNo, bool returnAll)
        {
            List<LedgerPosting> list = this.service.GetAll((LedgerPosting a) => a.InvoiceNo == InvoiceNo && a.IsActive).ToList<LedgerPosting>();
            return list;
        }
        public List<LedgerPosting> GetAll(DateTime fromDate, DateTime toDate)
        {
            List<LedgerPosting> list = this.service.GetAll((LedgerPosting a) => (a.PostingDate >= (DateTime?)fromDate) && (a.PostingDate <= (DateTime?)toDate) && a.IsActive).ToList<LedgerPosting>();
            return list;
        }
        public List<LedgerPosting> GetAll(DateTime fromDate, DateTime toDate, int VoucherTypeId)
        {
            List<LedgerPosting> list = this.service.GetAll((LedgerPosting a) => (a.PostingDate >= (DateTime?)fromDate) && (a.PostingDate <= (DateTime?)toDate) && a.VoucherTypeId == (int?)VoucherTypeId && a.IsActive).ToList<LedgerPosting>();
            return list;
        }

        public List<LedgerPosting> GetAll(DateTime fromDate,DateTime toDate, int ledgerId,int VoucherTypeId)
        {
            return service.GetAll(a=>a.PostingDate>=fromDate&&a.PostingDate<=toDate&&a.LedgerId== ledgerId &&a.VoucherTypeId== VoucherTypeId &&a.IsActive!=false).ToList();
        }

        public DataTable GetIncomeStatement(DateTime fromDate,DateTime toDate)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter param1 = new SqlParameter("@fromDate", DateTime.Now.AddMonths(-1));
            parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@toDate", DateTime.Now);
            parameters.Add(param2);
            var get = service.ExecuteProcedure("Exec StockOutChallanList @fromDate,@toDate", parameters,true);
            return get;
        }
        public List<TrailBalanceResponse> TrailBalance(DateTime fromDate, DateTime toDate)
        {
            List<TrailBalanceResponse> ress = new List<TrailBalanceResponse>();
            var Accounts = _AccountsService.GetAll().ToList();
           // var ledgers = ledgerService.GetAll().ToList();
            var ledgerPosting = GetAll(fromDate, toDate).ToList();
            var primaryAccounts = Accounts.Where(a => a.GroupUnder == 0);
            var si = 1;
            foreach (AccountGroup item in primaryAccounts)
            {
                var trailBalance = new TrailBalanceResponse();
                trailBalance.SI = si;
                trailBalance.Particular = item.AccountGroupName;
                trailBalance.ParticularId = item.Id;

                //ledgers
                var ledgerList = Ledgers(item, Accounts);
                var ledgerIds = ledgerList.Select(a => a.Id).ToList();
                var postingWithLedgers = ledgerPosting.Where(a => ledgerIds.Contains(a.LedgerId ?? 0)).ToList();
                //openning
                var openningCredit = postingWithLedgers.Where(a => a.VoucherTypeId == (int)VoucherTypeEnum.OpeningBalance).Sum(a => (a.Credit));
                var openningDebit = postingWithLedgers.Where(a => a.VoucherTypeId == (int)VoucherTypeEnum.OpeningBalance).Sum(a => (a.Debit));
                trailBalance.Opening = Math.Abs(openningDebit??0 - openningCredit??0);
                trailBalance.OpeningType = trailBalance.Opening.ToString()+ (openningCredit > openningDebit ? "Cr" : "Dr");
                //debit credit
                trailBalance.Credit = postingWithLedgers.Where(a => a.VoucherTypeId != (int)VoucherTypeEnum.OpeningBalance).Sum(a => a.Credit??0);
                trailBalance.Debit = postingWithLedgers.Where(a => a.VoucherTypeId != (int)VoucherTypeEnum.OpeningBalance).Sum(a => a.Debit??0);
                trailBalance.BalanceType = trailBalance.Balance.ToString()+(trailBalance.Credit> trailBalance.Debit ? "Cr" : "Dr");
                trailBalance.Balance = Math.Abs(trailBalance.Credit - trailBalance.Debit);
                ress.Add(trailBalance);
                si++;
            }
            return ress;
        }

        private List<AccountLedger> Ledgers(AccountGroup head,List<AccountGroup> groups)
        {
            var ledgerList = new List<AccountLedger>();
            foreach (var item in head.AccountLedgers)
            {
                ledgerList.Add(item);
            }
            var group = groups.Where(a => a.GroupUnder == head.Id);
            foreach (var item in group)
            {
                foreach (var l in item.AccountLedgers)
                {
                    ledgerList.Add(l);
                }
            }
            return ledgerList;
        }
        public LedgerPosting GetById(int? id = 0)
        {
            return service.GetById(id);
        }
        public LedgerPosting Save(LedgerPosting ledger)
        {
            var ledgerDetails = ledgerService.GetById(ledger.LedgerId);
           // var isExists = service.GetAll().Where(a => a.InvoiceNo == ledger.InvoiceNo && a.LedgerId == ledger.LedgerId).FirstOrDefault();
            var max = service.LastRow().OrderByDescending(a => a.Id).FirstOrDefault();
            if (max==null)
            {
                ledger.Id = 1;
            }
            else
            {
                ledger.Id = max.Id + 1;

            }
            
            if (ledger.VoucherNo == null)
            {
                ledger.VoucherNo = max.VoucherNo + 1;
            }
            ledger.CreatedDate = DateTime.Now;
            ledger.CreatedBy = CurrentSession.GetCurrentSession().UserId;
            ledger.YearId = CurrentSession.GetCurrentSession().FinancialYear;
            ledger.IsLastYear = true;
            ledger.IsActive = true;
            var result=service.Save(ledger);
            return result;

        }

        public AdditionalCost AddCostSave(AdditionalCost addCost)
        {
            var isExists = addCostService.GetAll().Where(a => a.VoucherNo == addCost.VoucherNo && a.LedgerId == addCost.LedgerId).FirstOrDefault();
            var max = addCostService.LastRow().OrderByDescending(a => a.Id).FirstOrDefault();
            if (max == null)
            {
                addCost.Id = 1;
            }
            else
            {
                addCost.Id = max.Id + 1;

            }
            var result = addCostService.Save(addCost);
            return result;

        }
        public Tuple<bool,string> IsSundryDrCr(int ledgerId)
        {
            var checkLedger = ledgerService.GetById(ledgerId);
            if (checkLedger.AccountGroupId==26)
            {
                return new Tuple<bool, string>(true, "Dr");
            }
            if (checkLedger.AccountGroupId == 22)
            {
                return new Tuple<bool, string>(true, "Cr");
            }
            
             return new Tuple<bool, string>(false, "");
        }
        public LedgerPosting Update(LedgerPosting t, int id)
        {
            return service.Update(t, id);
        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }

    }
}