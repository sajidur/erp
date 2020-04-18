using System.Collections.Generic;
using System.Web.Mvc;

namespace RexERP_MVC.ViewModel
{
    public class FinancialYearView
    {
        public int SelectedYearId { get; set; }
        public IEnumerable<SelectListItem> FinancialYears { get; set; }
    }
}