using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class HoliDayResponse
    {
        public int HOLIDAYID { get; set; }
        public string HOLIDAYNAME { get; set; }
        public Nullable<short> HOLIDAYYEAR { get; set; }
        public Nullable<short> HOLIDAYMONTH { get; set; }
        public Nullable<short> HOLIDAYDAY { get; set; }
        public Nullable<System.DateTime> STARTTIME { get; set; }
        public Nullable<short> DURATION { get; set; }
        public Nullable<short> HOLIDAYTYPE { get; set; }
        public string XINBIE { get; set; }
        public string MINZU { get; set; }
        public Nullable<short> DeptID { get; set; }
        public Nullable<int> timezone { get; set; }
    }
}