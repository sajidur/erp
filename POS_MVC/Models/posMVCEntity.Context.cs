﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RexERP_MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountGroup> AccountGroups { get; set; }
        public virtual DbSet<AccountLedger> AccountLedgers { get; set; }
        public virtual DbSet<ACGroup> ACGroups { get; set; }
        public virtual DbSet<ACTimeZone> ACTimeZones { get; set; }
        public virtual DbSet<ACUnlockComb> ACUnlockCombs { get; set; }
        public virtual DbSet<AdditionalCost> AdditionalCosts { get; set; }
        public virtual DbSet<AdvancePayment> AdvancePayments { get; set; }
        public virtual DbSet<AlarmLog> AlarmLogs { get; set; }
        public virtual DbSet<AttParam> AttParams { get; set; }
        public virtual DbSet<AuditedExc> AuditedExcs { get; set; }
        public virtual DbSet<AUTHDEVICE> AUTHDEVICEs { get; set; }
        public virtual DbSet<BankReconciliation> BankReconciliations { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CHECKEXACT> CHECKEXACTs { get; set; }
        public virtual DbSet<CHECKINOUT> CHECKINOUTs { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ContraDetail> ContraDetails { get; set; }
        public virtual DbSet<ContraMaster> ContraMasters { get; set; }
        public virtual DbSet<CreditNoteMaster> CreditNoteMasters { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTS { get; set; }
        public virtual DbSet<DeptUsedSch> DeptUsedSchs { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FaceTemp> FaceTemps { get; set; }
        public virtual DbSet<FinancialYear> FinancialYears { get; set; }
        public virtual DbSet<HOLIDAY> HOLIDAYS { get; set; }
        public virtual DbSet<JournalDetail> JournalDetails { get; set; }
        public virtual DbSet<JournalMaster> JournalMasters { get; set; }
        public virtual DbSet<LeaveClass> LeaveClasses { get; set; }
        public virtual DbSet<LeaveClass1> LeaveClass1 { get; set; }
        public virtual DbSet<LedgerPosting> LedgerPostings { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<NUM_RUN> NUM_RUN { get; set; }
        public virtual DbSet<NUM_RUN_DEIL> NUM_RUN_DEIL { get; set; }
        public virtual DbSet<PartyBalance> PartyBalances { get; set; }
        public virtual DbSet<PartyPaymentHistory> PartyPaymentHistories { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<ReceiveDetail> ReceiveDetails { get; set; }
        public virtual DbSet<ReceiveMaster> ReceiveMasters { get; set; }
        public virtual DbSet<ReportItem> ReportItems { get; set; }
        public virtual DbSet<RoleWiseScreenPermission> RoleWiseScreenPermissions { get; set; }
        public virtual DbSet<SalaryPayment> SalaryPayments { get; set; }
        public virtual DbSet<SalesDelivery> SalesDeliveries { get; set; }
        public virtual DbSet<SalesMaster> SalesMasters { get; set; }
        public virtual DbSet<SalesReturn> SalesReturns { get; set; }
        public virtual DbSet<SchClass> SchClasses { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<SECURITYDETAIL> SECURITYDETAILS { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<SHIFT> SHIFTs { get; set; }
        public virtual DbSet<StockOut> StockOuts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemLog> SystemLogs { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<TBSMSALLOT> TBSMSALLOTs { get; set; }
        public virtual DbSet<TBSMSINFO> TBSMSINFOes { get; set; }
        public virtual DbSet<TEMPLATE> TEMPLATEs { get; set; }
        public virtual DbSet<TempSalesMaster> TempSalesMasters { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<USER_OF_RUN> USER_OF_RUN { get; set; }
        public virtual DbSet<USER_SPEDAY> USER_SPEDAY { get; set; }
        public virtual DbSet<USER_TEMP_SCH> USER_TEMP_SCH { get; set; }
        public virtual DbSet<UserACMachine> UserACMachines { get; set; }
        public virtual DbSet<UserACPrivilege> UserACPrivileges { get; set; }
        public virtual DbSet<USERINFO> USERINFOes { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserUpdate> UserUpdates { get; set; }
        public virtual DbSet<UserUsedSClass> UserUsedSClasses { get; set; }
        public virtual DbSet<VoucherType> VoucherTypes { get; set; }
        public virtual DbSet<WareHouse> WareHouses { get; set; }
        public virtual DbSet<EmOpLog> EmOpLogs { get; set; }
        public virtual DbSet<ServerLog> ServerLogs { get; set; }
        public virtual DbSet<UsersMachine> UsersMachines { get; set; }
        public virtual DbSet<ProductInfo> ProductInfoes { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<StockIn> StockIns { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }
        public virtual DbSet<TempSalesDetail> TempSalesDetails { get; set; }
        public virtual DbSet<SalesDetail> SalesDetails { get; set; }
    
        public virtual int BalanceReconcilation(Nullable<int> ledgerId, Nullable<int> yearId)
        {
            var ledgerIdParameter = ledgerId.HasValue ?
                new ObjectParameter("ledgerId", ledgerId) :
                new ObjectParameter("ledgerId", typeof(int));
    
            var yearIdParameter = yearId.HasValue ?
                new ObjectParameter("yearId", yearId) :
                new ObjectParameter("yearId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BalanceReconcilation", ledgerIdParameter, yearIdParameter);
        }
    
        public virtual ObjectResult<CashBook_Result> CashBook(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CashBook_Result>("CashBook", fromDateParameter, toDateParameter);
        }
    
        public virtual int ClearData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ClearData");
        }
    
        public virtual ObjectResult<CustomerDueSummary_Result> CustomerDueSummary()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CustomerDueSummary_Result>("CustomerDueSummary");
        }
    
        public virtual ObjectResult<DailyReceiveAndPayment_Result> DailyReceiveAndPayment(Nullable<int> customerOrSupplier, string fromDate, string toDate)
        {
            var customerOrSupplierParameter = customerOrSupplier.HasValue ?
                new ObjectParameter("customerOrSupplier", customerOrSupplier) :
                new ObjectParameter("customerOrSupplier", typeof(int));
    
            var fromDateParameter = fromDate != null ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(string));
    
            var toDateParameter = toDate != null ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DailyReceiveAndPayment_Result>("DailyReceiveAndPayment", customerOrSupplierParameter, fromDateParameter, toDateParameter);
        }
    
        public virtual ObjectResult<DailyTransaction_Result> DailyTransaction(Nullable<int> ledgerId, Nullable<int> customerOrSupplier, Nullable<int> yearId)
        {
            var ledgerIdParameter = ledgerId.HasValue ?
                new ObjectParameter("LedgerId", ledgerId) :
                new ObjectParameter("LedgerId", typeof(int));
    
            var customerOrSupplierParameter = customerOrSupplier.HasValue ?
                new ObjectParameter("customerOrSupplier", customerOrSupplier) :
                new ObjectParameter("customerOrSupplier", typeof(int));
    
            var yearIdParameter = yearId.HasValue ?
                new ObjectParameter("yearId", yearId) :
                new ObjectParameter("yearId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DailyTransaction_Result>("DailyTransaction", ledgerIdParameter, customerOrSupplierParameter, yearIdParameter);
        }
    
        public virtual ObjectResult<DueSummary_Result> DueSummary(Nullable<int> financialYear, Nullable<int> reportType, Nullable<int> yearId)
        {
            var financialYearParameter = financialYear.HasValue ?
                new ObjectParameter("FinancialYear", financialYear) :
                new ObjectParameter("FinancialYear", typeof(int));
    
            var reportTypeParameter = reportType.HasValue ?
                new ObjectParameter("ReportType", reportType) :
                new ObjectParameter("ReportType", typeof(int));
    
            var yearIdParameter = yearId.HasValue ?
                new ObjectParameter("yearId", yearId) :
                new ObjectParameter("yearId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DueSummary_Result>("DueSummary", financialYearParameter, reportTypeParameter, yearIdParameter);
        }
    
        public virtual ObjectResult<GetBalance_Result> GetBalance(Nullable<int> ledgerId, Nullable<int> yearId)
        {
            var ledgerIdParameter = ledgerId.HasValue ?
                new ObjectParameter("ledgerId", ledgerId) :
                new ObjectParameter("ledgerId", typeof(int));
    
            var yearIdParameter = yearId.HasValue ?
                new ObjectParameter("yearId", yearId) :
                new ObjectParameter("yearId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBalance_Result>("GetBalance", ledgerIdParameter, yearIdParameter);
        }
    
        public virtual ObjectResult<GetCustomerBalance_Result> GetCustomerBalance(Nullable<int> ledgerId)
        {
            var ledgerIdParameter = ledgerId.HasValue ?
                new ObjectParameter("ledgerId", ledgerId) :
                new ObjectParameter("ledgerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCustomerBalance_Result>("GetCustomerBalance", ledgerIdParameter);
        }
    
        public virtual ObjectResult<GetPartyPayment_Result> GetPartyPayment(Nullable<int> ledgerId, Nullable<int> customerOrSupplier)
        {
            var ledgerIdParameter = ledgerId.HasValue ?
                new ObjectParameter("LedgerId", ledgerId) :
                new ObjectParameter("LedgerId", typeof(int));
    
            var customerOrSupplierParameter = customerOrSupplier.HasValue ?
                new ObjectParameter("customerOrSupplier", customerOrSupplier) :
                new ObjectParameter("customerOrSupplier", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPartyPayment_Result>("GetPartyPayment", ledgerIdParameter, customerOrSupplierParameter);
        }
    
        public virtual ObjectResult<IncomeStatement_Result> IncomeStatement(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<IncomeStatement_Result>("IncomeStatement", fromDateParameter, toDateParameter);
        }
    
        public virtual ObjectResult<ProductWiseBestSales_Result> ProductWiseBestSales()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductWiseBestSales_Result>("ProductWiseBestSales");
        }
    
        public virtual ObjectResult<ReceiveReport_Result> ReceiveReport(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, Nullable<int> supplierId)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(System.DateTime));
    
            var supplierIdParameter = supplierId.HasValue ?
                new ObjectParameter("supplierId", supplierId) :
                new ObjectParameter("supplierId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReceiveReport_Result>("ReceiveReport", fromDateParameter, toDateParameter, supplierIdParameter);
        }
    
        public virtual ObjectResult<rptCustomerLedger_Result> rptCustomerLedger(Nullable<int> ledgerId, Nullable<int> type, Nullable<int> yearId, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var ledgerIdParameter = ledgerId.HasValue ?
                new ObjectParameter("ledgerId", ledgerId) :
                new ObjectParameter("ledgerId", typeof(int));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(int));
    
            var yearIdParameter = yearId.HasValue ?
                new ObjectParameter("yearId", yearId) :
                new ObjectParameter("yearId", typeof(int));
    
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rptCustomerLedger_Result>("rptCustomerLedger", ledgerIdParameter, typeParameter, yearIdParameter, fromDateParameter, toDateParameter);
        }
    
        public virtual ObjectResult<rptCustomerRecive_Result> rptCustomerRecive(Nullable<int> customerId, string invoiceId)
        {
            var customerIdParameter = customerId.HasValue ?
                new ObjectParameter("CustomerId", customerId) :
                new ObjectParameter("CustomerId", typeof(int));
    
            var invoiceIdParameter = invoiceId != null ?
                new ObjectParameter("invoiceId", invoiceId) :
                new ObjectParameter("invoiceId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rptCustomerRecive_Result>("rptCustomerRecive", customerIdParameter, invoiceIdParameter);
        }
    
        public virtual ObjectResult<rptCustomerTransaction_Result> rptCustomerTransaction(Nullable<int> customerId)
        {
            var customerIdParameter = customerId.HasValue ?
                new ObjectParameter("CustomerId", customerId) :
                new ObjectParameter("CustomerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rptCustomerTransaction_Result>("rptCustomerTransaction", customerIdParameter);
        }
    
        public virtual ObjectResult<rptIndividualLedger_Result> rptIndividualLedger(Nullable<int> customerId, Nullable<int> isLedger, Nullable<int> isSupplier, string invoiceId)
        {
            var customerIdParameter = customerId.HasValue ?
                new ObjectParameter("CustomerId", customerId) :
                new ObjectParameter("CustomerId", typeof(int));
    
            var isLedgerParameter = isLedger.HasValue ?
                new ObjectParameter("IsLedger", isLedger) :
                new ObjectParameter("IsLedger", typeof(int));
    
            var isSupplierParameter = isSupplier.HasValue ?
                new ObjectParameter("IsSupplier", isSupplier) :
                new ObjectParameter("IsSupplier", typeof(int));
    
            var invoiceIdParameter = invoiceId != null ?
                new ObjectParameter("invoiceId", invoiceId) :
                new ObjectParameter("invoiceId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rptIndividualLedger_Result>("rptIndividualLedger", customerIdParameter, isLedgerParameter, isSupplierParameter, invoiceIdParameter);
        }
    
        public virtual ObjectResult<rptSalesInvoice_Result> rptSalesInvoice(string salesInvoice)
        {
            var salesInvoiceParameter = salesInvoice != null ?
                new ObjectParameter("SalesInvoice", salesInvoice) :
                new ObjectParameter("SalesInvoice", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rptSalesInvoice_Result>("rptSalesInvoice", salesInvoiceParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<StockOutChallanList_Result> StockOutChallanList(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StockOutChallanList_Result>("StockOutChallanList", fromDateParameter, toDateParameter);
        }
    
        public virtual ObjectResult<StockOutInvoice_Result> StockOutInvoice(string invoiceNo)
        {
            var invoiceNoParameter = invoiceNo != null ?
                new ObjectParameter("InvoiceNo", invoiceNo) :
                new ObjectParameter("InvoiceNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StockOutInvoice_Result>("StockOutInvoice", invoiceNoParameter);
        }
    
        public virtual int YearClosed(Nullable<int> customerId)
        {
            var customerIdParameter = customerId.HasValue ?
                new ObjectParameter("CustomerId", customerId) :
                new ObjectParameter("CustomerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("YearClosed", customerIdParameter);
        }
    }
}
