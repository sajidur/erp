using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class ChartOfAccount:AccountsBaseResponse
    {      
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string Particular { get; set; }
        public string DrOrCr { get; set; }
        public int SI { get; set; }
    }
}