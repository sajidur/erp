using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class SalaryItemNewViewModel
    {
        public int id { get; set; }
        public string SalaryItemName { get; set; }
        public Nullable<decimal> Percentage { get; set; }
        public string Description { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}