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
    
    public partial class FPUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FPUser()
        {
            this.FPAttLogs = new HashSet<FPAttLog>();
            this.FPTemplates = new HashSet<FPTemplate>();
        }
    
        public int Id { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public int PIN { get; set; }
        public byte Privilege { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Card { get; set; }
        public byte Group { get; set; }
        public string TimeZones { get; set; }
        public long PIN2 { get; set; }
        public int VerifyMode { get; set; }
        public string Reserved { get; set; }
        public string Remark { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsInSync { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FPAttLog> FPAttLogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FPTemplate> FPTemplates { get; set; }
    }
}
