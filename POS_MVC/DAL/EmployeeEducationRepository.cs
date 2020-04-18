using Core.Interface.Repository;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class EmployeeEducationRepository : EfRepository<EmployeeEducation>, IEmployeeEducationRepository
    {
        private Entities entities;
        public EmployeeEducationRepository()
        {
            entities = new Entities();
        }

        public IQueryable<EmployeeEducation> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<EmployeeEducation> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public EmployeeEducation GetObjectById(int Id)
        {
            EmployeeEducation employeeEducation = Find(x => x.Id == Id && !x.IsDeleted);
            return employeeEducation;
        }

        public EmployeeEducation CreateObject(EmployeeEducation employeeEducation)
        {
            employeeEducation.IsDeleted = false;
            employeeEducation.CreatedAt = DateTime.Now;
            return Create(employeeEducation);
        }

        public EmployeeEducation UpdateObject(EmployeeEducation employeeEducation)
        {
            employeeEducation.UpdatedAt = DateTime.Now;
            Update(employeeEducation);
            return employeeEducation;
        }

        public EmployeeEducation SoftDeleteObject(EmployeeEducation employeeEducation)
        {
            employeeEducation.IsDeleted = true;
            employeeEducation.DeletedAt = DateTime.Now;
            Update(employeeEducation);
            return employeeEducation;
        }

        public bool DeleteObject(int Id)
        {
            EmployeeEducation employeeEducation = Find(x => x.Id == Id);
            return (Delete(employeeEducation) == 1) ? true : false;
        }

        
    }
}