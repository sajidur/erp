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
    
    public partial class FaceTemp
    {
        public int TEMPLATEID { get; set; }
        public string USERNO { get; set; }
        public Nullable<int> SIZE { get; set; }
        public Nullable<int> pin { get; set; }
        public Nullable<int> FACEID { get; set; }
        public Nullable<int> VALID { get; set; }
        public Nullable<int> RESERVE { get; set; }
        public Nullable<int> ACTIVETIME { get; set; }
        public Nullable<int> VFCOUNT { get; set; }
        public byte[] TEMPLATE { get; set; }
        public Nullable<int> UserID { get; set; }
    }
}
