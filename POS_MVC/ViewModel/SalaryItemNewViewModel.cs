using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class PayHeadViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMainSalary { get; set; }
        public bool IsDetailSalary { get; set; }
        public int SalaryItemType { get; set; }
    }
}