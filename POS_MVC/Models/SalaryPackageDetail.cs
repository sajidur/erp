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
    
    public partial class SalaryPackageDetail
    {
        public int Id { get; set; }
        public int SalaryPackageId { get; set; }
        public Nullable<int> PayHeadId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Narration { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    
        public virtual SalaryPackage SalaryPackage { get; set; }
    }
}
