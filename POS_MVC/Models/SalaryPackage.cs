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
    
    public partial class SalaryPackage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalaryPackage()
        {
            this.SalaryPackageDetails = new HashSet<SalaryPackageDetail>();
        }
    
        public int Id { get; set; }
        public string SalaryPackageName { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string Description { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalaryPackageDetail> SalaryPackageDetails { get; set; }
    }
}
