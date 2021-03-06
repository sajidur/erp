﻿using System;

namespace RexERP_MVC.ViewModel
{
    public class DesignationtblResponse
    {
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}