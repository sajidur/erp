using RexERP_MVC.Models;
using RexERP_MVC.Util;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class PartyBalanceService
    {
        DBService<PartyBalance> service = new DBService<PartyBalance>();
        FinancialYearService year = new FinancialYearService();
        DBService<Supplier> supplierService = new DBService<Supplier>();
        DBService<Customer> _customerService = new DBService<Customer>();

        DBService<PartyPaymentResponse> pService = new DBService<PartyPaymentResponse>();
        DBService<DueSummaryResponse> dueSummaryService = new DBService<DueSummaryResponse>();
        private DBService<rptCustomerLedger_Result> ledgerService = new DBService<rptCustomerLedger_Result>();

        int yearId = 0;
        public PartyBalanceService()
        {
            var session=CurrentSession.GetCurrentSession();
            if (session!=null)
            {
                yearId = session.FinancialYear;
            }
        }
        public List<PartyBalance> GetAll()
        {
            return service.GetAll(a=>a.FinancialYearId==yearId).ToList();
        }

 
        public List<PartyPaymentResponse> DailyReceiveAndPayment(int customerOrSupplier,string fromDate,string toDate)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
           // var date = fromDate.Date.Date.ToString("yyyy-MM-dd");
            var get = pService.ExecuteProcedure("Exec DailyReceiveAndPayment '" + customerOrSupplier + "','"+fromDate+"','"+toDate+"'").OrderByDescending(a=>a.PostingDate).ToList();
            return get;
        }

        public List<DueSummaryResponse> GetDueSummary(int reportType)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var get = dueSummaryService.ExecuteProcedure("Exec DueSummary '" + CurrentSession.GetCurrentSession().FinancialYear + "','" + reportType + "',"+yearId+"");
            return get;

        }
        public List<rptCustomerLedger_Result> individualLedger(int type, int ledgerId,string fromDate,string toDate)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return this.ledgerService.ExecuteProcedure(string.Concat(new object[] { "Exec rptCustomerLedger '", ledgerId, "','", type, "',"+yearId+",'"+fromDate+"','"+toDate+"'" }));
        }
        public PartyBalance GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public PartyBalance Save(PartyBalance partyBalance)
        {
            var isExists = service.GetAll().Where(a=>a.LedgerId == partyBalance.LedgerId).OrderByDescending(a=>a.PartyBalanceId).FirstOrDefault();
            var max = service.LastRow().OrderByDescending(a => a.PartyBalanceId).FirstOrDefault();
            if (max==null)
            {
                partyBalance.PartyBalanceId = 1;
            }
            else
            {
                partyBalance.PartyBalanceId = max.PartyBalanceId + 1;

            }

            if (isExists != null)
            {
                if (partyBalance.Credit > 0)
                {
                    var newbalance = isExists.Balance + partyBalance.Credit;
                    partyBalance.Balance = newbalance;
                }
                if (partyBalance.Debit > 0)
                {
                    var newbalance = isExists.Balance - partyBalance.Debit;
                    partyBalance.Balance = newbalance;
                }

            }
            else
            {
                if (partyBalance.Credit > 0)
                {
                    partyBalance.Balance =  partyBalance.Credit;
                }
                if (partyBalance.Debit > 0)
                {
                    partyBalance.Balance = (-1)*partyBalance.Debit;
                }
            }
            partyBalance.FinancialYearId = CurrentSession.GetCurrentSession().FinancialYear;
            partyBalance.IsLastYear = true;
            service.Save(partyBalance);
            //if (partyBalance != null)
            //{
            //    SqlParameter param = new SqlParameter("@LedgerId", partyBalance.LedgerId);
            //    List<SqlParameter> paramss = new List<SqlParameter>();

            //    paramss.Add(param);
            //    service.ExecuteProcedure("Exec BalanceReconcilation " + partyBalance.LedgerId + "",paramss,true);
            //}
            return partyBalance;

        }
        public PartyBalance GetByVoucher(int ledgerId, string voucherNo)
        {
            PartyBalance partyBalance = this.service.GetAll((PartyBalance a) => a.LedgerId == ledgerId && a.VoucherNo == voucherNo &&a.FinancialYearId==yearId).FirstOrDefault<PartyBalance>();
            return partyBalance;
        }
        public PartyBalance GetByInvoiceNo(int ledgerId, string invoiceNo)
        {
            PartyBalance partyBalance = this.service.GetAll((PartyBalance a) => a.LedgerId == ledgerId && a.InvoiceNo == invoiceNo && a.FinancialYearId == yearId).FirstOrDefault<PartyBalance>();
            return partyBalance;
        }
        public PartyBalance GetByLedgerPostingId(int ledgerId, string ledgerPostingId,string voucherNo,string invoiceNo)
        {
            PartyBalance partyBalance = this.service.GetAll((PartyBalance a) => a.LedgerId == ledgerId && a.extra2 == ledgerPostingId &&a.FinancialYearId==yearId).FirstOrDefault<PartyBalance>();
            if (partyBalance==null)
            {
                partyBalance= this.service.GetAll((PartyBalance a) => a.LedgerId == ledgerId && (a.VoucherNo == voucherNo) && a.FinancialYearId == yearId).FirstOrDefault<PartyBalance>();
            }
            return partyBalance;
        }
        public PartyBalance Update(PartyBalance t, int id)
        {
            var res= service.Update(t, id);
            if (t != null)
            {
                service.ExecuteNonQuery("Exec BalanceReconcilation " + t.LedgerId + ","+yearId+"");
            }
            return res;
        }
        public int Delete(int id)
        {
            var balance = service.GetById(id);
            var res = service.Delete(id);
            if (balance != null)
            {
                service.ExecuteNonQuery("Exec BalanceReconcilation " + balance.LedgerId + "," + yearId + "");
            }
            return res;
        }

        public List<PartyAgeingReportResponse> AgeingReportSummary(DateTime fromDate, DateTime toDate)
        {
            List<PartyAgeingReportResponse> ageingReport = new List<PartyAgeingReportResponse>();
            var customers = _customerService.GetAll().ToList();
            var ids = customers.Select(a => a.LedgerId);
            var list = service.GetAll(a=>ids.Contains(a.LedgerId) && a.FinancialYearId == yearId).ToList();
            //firstSlab
            int i= 0;
            foreach (var item in customers)
            {
                i++;
                DateTime fDate = fromDate;
                DateTime tDate = toDate;

                PartyAgeingReportResponse customerWiseAgeing = new PartyAgeingReportResponse();
                customerWiseAgeing.SI = i;
                customerWiseAgeing.PartyName = item.Name;
                //total Receivable
                var transactions = list.Where(a => a.LedgerId == item.LedgerId).ToList();
                if (transactions!=null)
                {
                    var credit = transactions.Sum(a => a.Credit ?? 0);
                    var debit = transactions.Sum(a=>a.Debit ?? 0);

                    customerWiseAgeing.Receivable =Math.Abs(credit-debit);
                    customerWiseAgeing.ReceivableWithType = credit > debit ? customerWiseAgeing.Receivable + "Cr" : customerWiseAgeing.Receivable + "Dr";
                }

                //upto 0-30 Receivable
                tDate = fDate.AddDays(-30);
                var uppTo30Days = transactions.Where(a=>a.PostingDate.Value.Date < fDate.Date && a.PostingDate.Value.Date > tDate.Date).ToList();
                if (uppTo30Days != null)
                {
                    var credit = uppTo30Days.Sum(a => a.Credit ?? 0);
                    var debit = uppTo30Days.Sum(a => a.Debit ?? 0);

                    customerWiseAgeing.FirstSlab = Math.Abs(credit - debit);
                    customerWiseAgeing.FirstSlabWithType = credit > debit ? customerWiseAgeing.Receivable + "Cr" : customerWiseAgeing.Receivable + "Dr";
                }
                //upto 30-60 Receivable
                fDate = tDate;
                tDate = fDate.AddDays(-30);
                var uppTo60Days = transactions.Where(a => a.PostingDate.Value.Date < fDate.Date && a.PostingDate.Value.Date > tDate.Date).ToList();
                if (uppTo60Days != null)
                {
                    var credit = uppTo60Days.Sum(a => a.Credit ?? 0);
                    var debit = uppTo60Days.Sum(a => a.Debit ?? 0);

                    customerWiseAgeing.SecondSlab = Math.Abs(credit - debit);
                    customerWiseAgeing.SecondSlabWithType = credit > debit ? customerWiseAgeing.Receivable + "Cr" : customerWiseAgeing.Receivable + "Dr";
                }
                //upto 61-90 Receivable
                fDate = tDate;
                tDate = fDate.AddDays(-30);
                var uppTo90Days = transactions.Where(a => a.PostingDate.Value.Date < fDate.Date && a.PostingDate.Value.Date > tDate.Date).ToList();
                if (uppTo90Days != null)
                {
                    var credit = uppTo90Days.Sum(a => a.Credit ?? 0);
                    var debit = uppTo90Days.Sum(a => a.Debit ?? 0);

                    customerWiseAgeing.ThirdSlab = Math.Abs(credit - debit);
                    customerWiseAgeing.ThirdSlabWithType = credit > debit ? customerWiseAgeing.Receivable + "Cr" : customerWiseAgeing.Receivable + "Dr";
                }

                //upto 90-180 Receivable
                fDate = tDate;
                tDate = fDate.AddDays(-90);
                var uppTo180Days = transactions.Where(a => a.PostingDate.Value.Date < fDate.Date && a.PostingDate.Value.Date > tDate.Date).ToList();
                if (uppTo180Days != null)
                {
                    var credit = uppTo180Days.Sum(a => a.Credit ?? 0);
                    var debit = uppTo180Days.Sum(a => a.Debit ?? 0);

                    customerWiseAgeing.FourthSlab = Math.Abs(credit - debit);
                    customerWiseAgeing.FourthSlabWithType = credit > debit ? customerWiseAgeing.Receivable + "Cr" : customerWiseAgeing.Receivable + "Dr";
                }
                //upto 180 and above Receivable

                fDate = tDate;
                var restOf = transactions.Where(a => a.PostingDate.Value.Date < fDate.Date).ToList();
                if (restOf != null)
                {
                    var credit = restOf.Sum(a => a.Credit ?? 0);
                    var debit = restOf.Sum(a => a.Debit ?? 0);
                    customerWiseAgeing.FourthSlab = Math.Abs(credit - debit);
                    customerWiseAgeing.FourthSlabWithType = credit > debit ? customerWiseAgeing.Receivable + "Cr" : customerWiseAgeing.Receivable + "Dr";
                }
                ageingReport.Add(customerWiseAgeing);
            }
            return ageingReport;
        }
    }
}