using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.RequestModel
{
    public class BonusDeductionRequest
    {
        public DateTime Date { get; set; }
        public string  Notes { get; set; }
        public int EmployeeId { get; set; }
        public int ÀdditionAmount { get; set; }
        public int DeductionAmount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}