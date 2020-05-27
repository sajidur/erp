using RexERP_MVC.ViewModel;
using System;

namespace RexERP_MVC.RequestModel
{
    public class EmployeeRequest
    {
       // public EmployeeRequest()
      //  {
          //  imageView = new ImageViewModel();
      //  }
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Qualification { get; set; }
        public string BloodGroup { get; set; }
        public int SalaryPackage { get; set; }
        public string EmployeeType { get; set; }
        public string SalaryType { get; set; }
        public string Gender { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public string Photo { get; set; }
        public string MimeType { get; set; }
        public string Creator { get; set; }
        public string UpdateBy { get; set; }
        public string Remarks { get; set; }
    }
}