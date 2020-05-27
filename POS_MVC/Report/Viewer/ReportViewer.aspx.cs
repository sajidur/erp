using Microsoft.Reporting.WebForms;
using RexERP_MVC.BAL;
using RexERP_MVC.Util;
using System;
using System.Data;

namespace RexERP_MVC.Report.Viewer
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        Result oResult = new Result();
        SQLDAL oDAL = new SQLDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int yearId = CurrentSession.GetCurrentSession().FinancialYear;
                ReportViewer1.ShowPrintButton = true;
                try
                {
                    string reportType = Request.QueryString["ReportName"].ToString();
                    if (reportType == "RevenueReport")
                    {
                        //LoadRevenueReport();
                    }
                    if (reportType == "PurchaseInvoice")
                    {
                        PurchaseInvoice();
                    }
                    if (reportType == "SalesInvoice")
                    {
                        LoadInvoiceReport();
                    }
                    if (reportType == "StockInForProcessing")
                    {
                        StockInForProcessing();
                    }
                    if (reportType == "StockOutForProcessing")
                    {
                        StockOutForProcessing();
                    }
                    if (reportType == "CustomerDue")
                    {
                        LoadCustomerDueReport();
                    }
                    if (reportType == "SalesDescriptions")
                    {
                        LoadSalesDescriptions();
                    }
                    if (reportType == "SuplierTransaction")
                    {
                        SuplierTransaction(yearId);
                    }
                    if (reportType == "CustomerTransaction")
                    {
                        CustomerTransaction();
                    }
                    if (reportType=="IncomeStatement")
                    {
                        IncomeStatment();
                     
                    }
                    if (reportType == "LedgerReport")
                    {
                        LedgerReport();
                    }
                    if (reportType == "ReceiveVoucher")
                    {
                        ReceiveVoucher();
                    }
                    if (reportType == "PaymentVoucher")
                    {
                        PaymentVoucher();
                    }
                    if (reportType == "PaymentInitVoucher")
                    {
                        PaymentInitVoucher();
                    }
                    if (reportType == "UnApprovedPaymentVoucherList")
                    {
                        UnApprovedPaymentVoucherList();
                    }
                    if (reportType == "JournalVoucher")
                    {
                        JournalVoucher();
                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message;
                }
            }
        }

        private void UnApprovedPaymentVoucherList()
        {
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec rptUnApprovedPaymentList";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/UnApprovedPaymentList.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsrptUnApprovedPaymentList", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }

        private void PaymentInitVoucher()
        {
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec rptPaymentInitateVoucher '" + invoiceId + "'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptPaymentInitiateVoucher.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsPaymentInitiateVoucher", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }

        private void JournalVoucher()
        {
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec SP_JournalVoucher '" + invoiceId + "'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptJournalVoucher.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsJournalVoucher", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }

        private void ReceiveVoucher()
        {
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec ReceiveVoucher '" + invoiceId + "'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptReceiveVoucher.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsReceiveVoucher", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }

        private void PaymentVoucher()
        {
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec PaymentVoucher '" + invoiceId + "'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptPaymentVoucher.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsPaymentVoucher", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }
        private void PurchaseInvoice()
        {
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec rptPurchaseChallan '" + invoiceId + "'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptPurchaseInvoice.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsPurchaseChallan", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }
        private void StockInForProcessing()
        {
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec StockInInvoice '" + invoiceId + "'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptStockInProcessing.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsProductProcessingInInvoice", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }

        private void LoadInvoiceReport()
        {

            // LocalReport report = new LocalReport();
            // report.ReportPath = "~/Report/rptDeliveryReport.rdlc";
            // report.ReportEmbeddedResource = "WindowsFormsApplication1.Report.rptDeliveryReport.rdlc";
            //  ReportDataSource rds = new ReportDataSource("rptInvoice", dt);
            //  report.Refresh();

           
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptSalesInvoice.rdlc");
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec rptSalesInvoice '" + invoiceId + "'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportDataSource datasource = new ReportDataSource("dsSalesInvoice", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;

            this.ReportViewer1.LocalReport.Refresh();


        }
        private void IncomeStatment()
        {
            string fromDate = Request.QueryString["fromDate"].ToString();
            string toDate = Request.QueryString["toDate"].ToString();
            string query = @"exec IncomeStatement '" + fromDate + "','"+toDate+"'";
            oResult = oDAL.Select(query);
            DataSet dt = null;
            dt = oResult.ds as DataSet;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptIncomeStatement.rdlc");
            ReportDataSource datasourceIncome = new ReportDataSource("IncomeStatementIncome", dt.Tables[0]);
            ReportDataSource datasourceExpense = new ReportDataSource("IncomeStatementExpense", dt.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncome);
            ReportViewer1.LocalReport.DataSources.Add(datasourceExpense);
        }
        private void StockOutForProcessing()
        {
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec StockOutInvoice '" + invoiceId+"'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptStockOutForProcessing.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsStockOutInvoice", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }

        private void LoadCustomerDueReport()
        {
            //string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec CustomerDueSummary";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rdlcCustomerDue.rdlc");
            ReportDataSource datasource = new ReportDataSource("CustomerDue", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
        }

        private void LoadSalesDescriptions()
        {
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec rptSalesDescription '" + invoiceId + "'"; //
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
           

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/SalesDescription.rdlc");
            ReportDataSource datasource = new ReportDataSource("SalesDescription", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            
            query = @"exec rptSalesDueDescription '" + invoiceId + "'";   //'" + customerId + "'
            oResult = oDAL.Select(query);
            dt = oResult.Data as DataTable;
            ReportDataSource customerDatasource = new ReportDataSource("SalesDueDescription", dt);

            ReportViewer1.LocalReport.DataSources.Add(customerDatasource);

            query = @"exec rptSalesCreditDescription '" + invoiceId + "'";   //'" + customerId + "'
            oResult = oDAL.Select(query);
            dt = oResult.Data as DataTable;
            ReportDataSource  SalesCreditDatasource = new ReportDataSource("SalesCreditDescription", dt);

            ReportViewer1.LocalReport.DataSources.Add(SalesCreditDatasource);
            ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
        }

        private void SuplierTransaction(int yearId)
        {
            string type = Request.QueryString["type"].ToString();
            string query = @"exec DueSummary '1',"+type+","+yearId+"";
            oResult = oDAL.Select(query);
            DataSet dt = null;
            dt = oResult.ds as DataSet;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptDueSummary.rdlc");
            ReportDataSource datasource = new ReportDataSource("dueSummary", dt.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
        }

        private void LedgerReport()
        {
            string type = Request.QueryString["type"].ToString();
            string ledgerId = Request.QueryString["ledgerId"].ToString();
            string isSupplier = Request.QueryString["IsSupplier"];
            string fromDate = Request.QueryString["fromDate"].ToString();
            string toDate = Request.QueryString["toDate"].ToString();
            var yearId= CurrentSession.GetCurrentSession().FinancialYear;
            string query = @"exec rptCustomerLedger '"+ ledgerId + "'," + type + "," + yearId + ",'" + fromDate + "','" + toDate + "'";
            oResult = oDAL.Select(query);
            DataSet dt = null;
            dt = oResult.ds as DataSet;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptCustomerLedger.rdlc");
            ReportDataSource datasource = new ReportDataSource("CustomerLedger", dt.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);


            query = @"exec GetCustomerBalance " + ledgerId + "";
            oResult = oDAL.Select(query);
            dt = oResult.ds as DataSet;
            ReportDataSource customerDatasource = new ReportDataSource("CustomerBalance", dt.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Add(customerDatasource);

            ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
        }

        private void CustomerTransaction()
        {
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec rptCustomerTransaction '" + invoiceId + "'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rdlcCustomerTransaction.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsCustomerTransaction", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
        }

    }
}