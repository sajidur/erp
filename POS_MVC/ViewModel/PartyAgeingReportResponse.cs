using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class PartyAgeingReportResponse
    {
        public int SI { get; set; }
        public string PartyName { get; set; }
        public decimal Receivable { get; set; }
        public decimal FirstSlab { get; set; }
        public decimal SecondSlab { get; set; }
        public decimal ThirdSlab { get; set; }
        public decimal FourthSlab { get; set; }
        public decimal FifthSlab { get; set; }
        public string ReceivableWithType { get; set; }
        public string FirstSlabWithType { get; set; }
        public string SecondSlabWithType { get; set; }
        public string ThirdSlabWithType { get; set; }
        public string FourthSlabWithType { get; set; }
        public string FifthSlabWithType { get; set; }
    }
}