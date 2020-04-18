using RexERP_MVC.Models;
using System.Collections.Generic;

namespace RexERP_MVC.ViewModel
{
    public class MenuPermission
    {
        public Screen MainModule { get; set; }
        public List<Screen> SubModules{get;set;}
    }
}