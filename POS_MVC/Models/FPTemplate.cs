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
    
    public partial class FPTemplate
    {
        public int Id { get; set; }
        public int FPUserId { get; set; }
        public int Size { get; set; }
        public int PIN { get; set; }
        public short FingerID { get; set; }
        public byte Valid { get; set; }
        public string Template { get; set; }
        public string AlgoVer { get; set; }
        public bool IsInSync { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        public virtual FPUser FPUser { get; set; }
    }
}
