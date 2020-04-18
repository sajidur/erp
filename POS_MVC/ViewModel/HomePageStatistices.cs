using System.Collections.Generic;
using RexERP_MVC.ViewModel;

namespace RexERP_MVC.Controllers
{
    public class HomePageStatistices
    {
        public HomePageStatistices()
        {
        }

        public double TodaySales { get; internal set; }
        public List<TopSellResponse> TopSell { get;  set; }
        public int TotalBranch { get; internal set; }
        public decimal TotalInventory { get; internal set; }
    }
}