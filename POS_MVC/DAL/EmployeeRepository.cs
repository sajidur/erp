using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RexERP_MVC.Models;

namespace Data.Repository
{
    public class EmployeeRepository : EfRepository<Employee>, IEmployeeRepository
    {
        private Entities entities;
        public EmployeeRepository()
        {
            entities = new Entities();
        }

        public IQueryable<Employee> GetQueryable()
        {
            return FindAll(x => !x.IsActive);
        }

        public IList<Employee> GetAll()
        {
            return FindAll(x =>x.IsActive==true).ToList();
        }

        public Employee GetObjectById(int Id)
        {
            Employee employee = FindAll(x => x.Id == Id && !x.IsActive).Include("Division").Include("TitleInfo").Include("EmployeeEducation").Include("LastEmployment").Include("EmployeeWorkingTimes").FirstOrDefault();
          //  if (employee != null) { employee.Errors = new Dictionary<string, string>(); }
            return employee;
        }

        public Employee GetObjectByNIK(string NIK)
        {
            return FindAll(x=>!x.IsActive).Include("Division").Include("TitleInfo").Include("EmployeeEducation").Include("LastEmployment").Include("EmployeeWorkingTimes").FirstOrDefault();
        }

        public Employee CreateObject(Employee employee)
        {
            employee.IsActive = false;
            employee.CreationDate = DateTime.Now;
            return Create(employee);
        }

        public Employee UpdateObject(Employee employee)
        {
            employee.UpdateDate = DateTime.Now;
            Update(employee);
            return employee;
        }

        public Employee SoftDeleteObject(Employee employee)
        {
            employee.IsActive = true;
            employee.UpdateDate = DateTime.Now;
            Update(employee);
            return employee;
        }

        public bool DeleteObject(int Id)
        {
            Employee employee = Find(x => x.Id == Id);
            return (Delete(employee) == 1) ? true : false;
        }

        public bool IsNIKDuplicated(Employee employee)
        {
            IQueryable<Employee> employees = FindAll(x => !x.IsActive && x.Id != employee.Id);
            return (employees.Count() > 0 ? true : false);
        }
    }
}