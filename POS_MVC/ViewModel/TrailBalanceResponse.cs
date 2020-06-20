using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class TrailBalanceResponse
    {
        public int level { get; set; }
        public int parent { get; set; }
        public bool isLeaf { get; set; }

        public int SI { get; set; }
        public int Id { get; set; }
        public int ParticularParentId { get; set; }
        public string ParticularParent { get; set; }
        public string Particular { get; set; }
        public decimal Opening { get; set; }
        public string OpeningType { get; set; }

        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public string BalanceType { get; set; }
        public bool expanded { get; set; }
    }
}