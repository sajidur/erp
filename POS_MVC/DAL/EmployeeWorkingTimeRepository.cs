using Core.Interface.Repository;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class EmployeeWorkingTimeRepository : EfRepository<EmployeeWorkingTime>, IEmployeeWorkingTimeRepository
    {
        private Entities entities;
        public EmployeeWorkingTimeRepository()
        {
            entities = new Entities();
        }

        public IQueryable<EmployeeWorkingTime> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<EmployeeWorkingTime> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public EmployeeWorkingTime GetObjectById(int Id)
        {
            EmployeeWorkingTime employeeWorkingTime = Find(x => x.Id == Id && !x.IsDeleted);
           // if (employeeWorkingTime != null) { employeeWorkingTime.Errors = new Dictionary<string, string>(); }
            return employeeWorkingTime;
        }

        public EmployeeWorkingTime CreateObject(EmployeeWorkingTime employeeWorkingTime)
        {
            employeeWorkingTime.IsDeleted = false;
            employeeWorkingTime.CreatedAt = DateTime.Now;
            return Create(employeeWorkingTime);
        }

        public EmployeeWorkingTime UpdateObject(EmployeeWorkingTime employeeWorkingTime)
        {
            employeeWorkingTime.UpdatedAt = DateTime.Now;
            Update(employeeWorkingTime);
            return employeeWorkingTime;
        }

        public EmployeeWorkingTime SoftDeleteObject(EmployeeWorkingTime employeeWorkingTime)
        {
            employeeWorkingTime.IsDeleted = true;
            employeeWorkingTime.DeletedAt = DateTime.Now;
            Update(employeeWorkingTime);
            return employeeWorkingTime;
        }

        public bool DeleteObject(int Id)
        {
            EmployeeWorkingTime employeeWorkingTime = Find(x => x.Id == Id);
            return (Delete(employeeWorkingTime) == 1) ? true : false;
        }

        
    }
}