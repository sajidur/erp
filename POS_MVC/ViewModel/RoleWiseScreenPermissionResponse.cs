using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class RoleWiseScreenPermissionResponse
    {
        public string RoleId { get; set; }
        public string ScreenId { get; set; }
        public int CompanyId { get; set; }
        public Nullable<System.DateTime> SetDate { get; set; }
        public string UserName { get; set; }

        public virtual MenuResponse Screen { get; set; }
        public virtual UserRoleResponse Role { get; set; }

    }
}