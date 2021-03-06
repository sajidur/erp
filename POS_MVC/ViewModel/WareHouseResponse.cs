﻿using System;

namespace RexERP_MVC.ViewModel
{
    public class WareHouseResponse
    {

        public int Id { get; set; }
        public string WareHouseName { get; set; }
        public string WareHouseAddress { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}