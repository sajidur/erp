using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class AccountsBaseResponse
    {
        public int Id { get; set; }
        public int level { get; set; }
        public int parent { get; set; }
        public bool isLeaf { get; set; }
        public bool expanded { get; set; }
    }
}