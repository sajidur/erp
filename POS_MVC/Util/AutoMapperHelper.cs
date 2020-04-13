using AutoMapper;
using RexERP_MVC.Models;
using RexERP_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.Util
{
    public class AutoMapperHelper
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserInfoResponse>().ReverseMap();
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


                cfg.CreateMap<Size, SizeResponse>().ReverseMap();
                });
        }
    }
}