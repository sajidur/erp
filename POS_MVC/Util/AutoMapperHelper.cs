using AutoMapper;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;

namespace RexERP_MVC.Util
{
    public class AutoMapperHelper
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryResponse>().ReverseMap();
                cfg.CreateMap<Product, ProductResponse>().ReverseMap();
                cfg.CreateMap<UserRole, UserRoleResponse>().ReverseMap();
                cfg.CreateMap<Brand, BrandResponse>().ReverseMap();
                cfg.CreateMap<Supplier, SupplierResponse>().ReverseMap();
                cfg.CreateMap<WareHouse, WareHouseResponse>().ReverseMap();
                cfg.CreateMap<Inventory, InventoryResponse>().ReverseMap();
                cfg.CreateMap<SalesMaster, SalesMasterResponse>().ReverseMap();
                cfg.CreateMap<SalesDetail, SalesDetailResponse>().ReverseMap();
                cfg.CreateMap<SalesOrder, SalesOrderResponse>().ReverseMap();
                cfg.CreateMap<ReceiveMaster, ReceiveMasterResponse>().ReverseMap();
                cfg.CreateMap<ReceiveDetail, ReceiveDetailResponse>().ReverseMap();
                cfg.CreateMap<AccountGroup, AccountGroupResponse>().ReverseMap();
                cfg.CreateMap<AccountLedger, AccountLedgerResponse>().ReverseMap();
                cfg.CreateMap<Customer, CustomerResponse>().ReverseMap();
                cfg.CreateMap<StockOut, StockOutResponse>().ReverseMap();
                cfg.CreateMap<LedgerPosting, LedgerPostingResponse>().ReverseMap();

                cfg.CreateMap<JournalMaster, JournalMasterResponse>().ReverseMap();
                cfg.CreateMap<JournalDetail, JournalDetailsResponse>().ReverseMap();
                cfg.CreateMap<rptCustomerLedger_Result, CustomerLedgerResultResponse>().ReverseMap();
                cfg.CreateMap<TempSalesMaster, TempSalesMasterResponse>().ReverseMap();
                cfg.CreateMap<TempSalesDetail, TempSalesDetailsResponse>().ReverseMap();
                cfg.CreateMap<CompanyResponse, Company>().ReverseMap();
                cfg.CreateMap<UserRoleResponse, UserRole>().ReverseMap();
                cfg.CreateMap<Screen, MenuResponse>().ReverseMap();
                cfg.CreateMap<User, UserInfoResponse>().ForMember(x => x.ContraMasters, opt => opt.Ignore()).ForMember(x => x.JournalMasters, opt => opt.Ignore()).ReverseMap();

                cfg.CreateMap<Employee, EmployeeResponse>().ReverseMap();

                cfg.CreateMap<Size, SizeResponse>().ReverseMap();
                cfg.CreateMap<Department, DEPARTMENTResponse>().ReverseMap();
                cfg.CreateMap<Designationtbl, DesignationtblResponse>().ReverseMap();
                cfg.CreateMap<API, APIResponse>().ReverseMap();
                cfg.CreateMap<PaymentMaster, PaymentMasterResponse>().ReverseMap();
                cfg.CreateMap<PaymentDetail, PaymentDetailResponse>().ReverseMap();
                cfg.CreateMap<RoleWiseScreenPermission, RoleWiseScreenPermissionResponse>().ForMember(a=>a.Role,opt=>opt.Ignore()).ReverseMap();
                cfg.CreateMap<PayHead, SalaryItemNewViewModel>().ReverseMap();


            });
        }
    }
}