﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class DEPARTMENTResponse
    {
        public int DEPTID { get; set; }
        public string DEPTNAME { get; set; }
        public int SUPDEPTID { get; set; }
        public Nullable<short> InheritParentSch { get; set; }
        public Nullable<short> InheritDeptSch { get; set; }
        public Nullable<short> InheritDeptSchClass { get; set; }
        public Nullable<short> AutoSchPlan { get; set; }
        public Nullable<short> InLate { get; set; }
        public Nullable<short> OutEarly { get; set; }
        public Nullable<short> InheritDeptRule { get; set; }
        public Nullable<int> MinAutoSchInterval { get; set; }
        public Nullable<short> RegisterOT { get; set; }
        public int DefaultSchId { get; set; }
        public Nullable<short> ATT { get; set; }
        public Nullable<short> Holiday { get; set; }
        public Nullable<short> OverTime { get; set; }
    }
}