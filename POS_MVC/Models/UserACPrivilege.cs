//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class UserACPrivilege
    {
        public int UserID { get; set; }
        public int DeviceID { get; set; }
        public Nullable<int> ACGroupID { get; set; }
        public Nullable<bool> IsUseGroup { get; set; }
        public Nullable<int> TimeZone1 { get; set; }
        public Nullable<int> TimeZone2 { get; set; }
        public Nullable<int> TimeZone3 { get; set; }
        public Nullable<int> verifystyle { get; set; }
    }
}
