﻿using RexERP_MVC.ViewModel;

namespace RexERP_MVC.Models
{
    public class AppSession
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserRoleId { get; set; }
        public bool UserStatus { get; set; }
        public int? BranchId { set; get; }
        public string UserTenancyName { set; get; }
        public string UserTenancyAddress { set; get; }
        public int FinancialYear { get; set; }
        public CompanyResponse Company { get; set; }

    }
}