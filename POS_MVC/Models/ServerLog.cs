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
    
    public partial class ServerLog
    {
        public int ID { get; set; }
        public string EVENT { get; set; }
        public int USERID { get; set; }
        public string EnrollNumber { get; set; }
        public Nullable<short> parameter { get; set; }
        public System.DateTime EVENTTIME { get; set; }
        public string SENSORID { get; set; }
        public string OPERATOR { get; set; }
    }
}
