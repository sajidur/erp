using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RexERP_MVC.ViewModel
{
    public class EmployeeSalaryProcessViewResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
        public int LateCount { get; set; }
        public int AttendanceCount { get; set; }
        public int LeaveCount { get; set; }
        public int AbsenceCount { get; set; }
        public decimal DeductionAmount { get; set; }
        public decimal AdditionAmount { get; set; }
        public decimal Salary { get; internal set; }
    }
}