using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class UserInfoResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserRoleId { get; set; }
        public bool UserStatus { get; set; }
        public Nullable<System.DateTime> SetDate { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<int> BranchId { get; set; }

        public virtual ICollection<ContraMaster> ContraMasters { get; set; }
        public virtual ICollection<JournalMasterResponse> JournalMasters { get; set; }
        public virtual UserRoleResponse UserRole { get; set; }
    }
}