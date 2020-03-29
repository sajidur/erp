using Microsoft.Reporting.WebForms;
using RexERP_MVC.BAL;
using RexERP_MVC.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                    if (reportType == "EXECLIPARTReport")
                    {
                        // LoadEXECLIPARTReport();
                    }
                    if (reportType == "SalesInvoice")
                    {
                        LoadInvoiceReport();
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

                    if (reportType == "AllGoodReceiveReport")
                    {
                        LoadShowAllGoodReceiveReport();
                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message;
                }
            }
        }

        private void LoadShowAllGoodReceiveReport()
        {
            string fromDate = Request.QueryString["fromDate"].ToString();
            string toDate = Request.QueryString["toDate"].ToString();
            string supplierId = Request.QueryString["supplierId"].ToString();

            string query = @"exec SP_GetAllReceiveReport";
            oResult = oDAL.Select(query);
            DataSet dt = null;
            dt = oResult.ds as DataSet;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptAllReceiveReport.rdlc");
            ReportDataSource datasourceIncome = new ReportDataSource("AllReceiveReport", dt.Tables[0]);
            
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasourceIncome);
        }    

        private void LoadInvoiceReport()
        {

            // LocalReport report = new LocalReport();
            // report.ReportPath = "~/Report/rptDeliveryReport.rdlc";
            // report.ReportEmbeddedResource = "WindowsFormsApplication1.Report.rptDeliveryReport.rdlc";
            //  ReportDataSource rds = new ReportDataSource("rptInvoice", dt);
            //  report.Refresh();

           
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/ChallanMainReport.rdlc");
            ReportViewer1.LocalReport.SubreportProcessing += new
                              SubreportProcessingEventHandler(SetSubDataSource);
            ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
            this.ReportViewer1.LocalReport.Refresh();


        }

        private void SetSubDataSource(object sender, SubreportProcessingEventArgs e)
        {
            btnTruckChallan.Visible = true;
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec rptSalesInvoice '" + invoiceId + "'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportDataSource datasource = new ReportDataSource("dsSalesInvoice", dt);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(datasource);
            e.DataSources.Add(new ReportDataSource("dsSalesInvoice", dt));


            string customerId = Request.QueryString["customerid"].ToString();
            query = @"exec rptIndividualLedger " + customerId + ",0,0,'"+invoiceId+"'";
            oResult = oDAL.Select(query);
            dt = oResult.Data as DataTable;
             ReportDataSource customerDatasource = new ReportDataSource("individualLedger", dt);
            //ReportViewer1.LocalReport.DataSources.Add(customerDatasource);
            e.DataSources.Add(new ReportDataSource("individualLedger", dt));

            query = @"exec rptCustomerRecive " + customerId + ","+ invoiceId + "";
            oResult = oDAL.Select(query);
            dt = oResult.Data as DataTable;
            ReportDataSource transactionDatasource = new ReportDataSource("rptCustomerTransaction", dt);
            //ReportViewer1.LocalReport.DataSources.Add(transactionDatasource);
            e.DataSources.Add(new ReportDataSource("rptCustomerTransaction", dt));

           // ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;
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

        protected void btnTruckChallan_Click(object sender, EventArgs e)
        {
            //btnTruckChallan.Visible = true;
            //string invoiceId = Request.QueryString["invoiceId"].ToString();
            //string query = @"exec rptSalesInvoice '" + invoiceId + "'";
            //oResult = oDAL.Select(query);
            //DataTable dt = null;
            //dt = oResult.Data as DataTable;

            //ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/rptTruckChallanInvoice.rdlc");
            //ReportDataSource datasource = new ReportDataSource("dsSalesInvoice", dt);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(datasource);

            //string customerId = Request.QueryString["customerid"].ToString();
            //query = @"exec rptIndividualLedger " + customerId + "";
            //oResult = oDAL.Select(query);
            //dt = oResult.Data as DataTable;
            //ReportDataSource customerDatasource = new ReportDataSource("individualLedger", dt);
            //ReportViewer1.LocalReport.DataSources.Add(customerDatasource);

            //query = @"exec rptCustomerRecive " + customerId + "";
            //oResult = oDAL.Select(query);
            //dt = oResult.Data as DataTable;
            //ReportDataSource transactionDatasource = new ReportDataSource("rptCustomerTransaction", dt);
            //ReportViewer1.LocalReport.DataSources.Add(transactionDatasource);


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/RPT/TrackChallanMain.rdlc");
            ReportViewer1.LocalReport.SubreportProcessing += new
                              SubreportProcessingEventHandler(TrackDataSource);
            ReportViewer1.ZoomMode = Microsoft.Reporting.WebForms.ZoomMode.PageWidth;

            this.ReportViewer1.LocalReport.Refresh();

        }

        private void TrackDataSource(object sender, SubreportProcessingEventArgs e)
        {
            btnTruckChallan.Visible = true;
            string invoiceId = Request.QueryString["invoiceId"].ToString();
            string query = @"exec rptSalesInvoice '" + invoiceId + "'";
            oResult = oDAL.Select(query);
            DataTable dt = null;
            dt = oResult.Data as DataTable;
            ReportDataSource datasource = new ReportDataSource("dsSalesInvoice", dt);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(datasource);
            e.DataSources.Add(new ReportDataSource("dsSalesInvoice", dt));


            string customerId = Request.QueryString["customerid"].ToString();
            //query = @"exec rptBalanceByInvoice " + customerId + ",0,0,'" + invoiceId + "'";
            query = @"exec rptIndividualLedger " + customerId + ",0,0,'" + invoiceId + "'";

            oResult = oDAL.Select(query);
            dt = oResult.Data as DataTable;
            ReportDataSource customerDatasource = new ReportDataSource("individualLedger", dt);
            //ReportViewer1.LocalReport.DataSources.Add(customerDatasource);
            e.DataSources.Add(new ReportDataSource("individualLedger", dt));

            // query = @"exec rptCustomerRecive " + customerId + "";
            query = @"exec rptCustomerRecive " + customerId + "," + invoiceId + "";

            oResult = oDAL.Select(query);
            dt = oResult.Data as DataTable;
            ReportDataSource transactionDatasource = new ReportDataSource("rptCustomerTransaction", dt);
            //ReportViewer1.LocalReport.DataSources.Add(transactionDatasource);
            e.DataSources.Add(new ReportDataSource("rptCustomerTransaction", dt));
        }
    }
}