﻿using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IQueryable<Employee> GetQueryable();
        IList<Employee> GetAll();
        Employee GetObjectById(int Id);
        Employee GetObjectByNIK(string NIK);
        Employee CreateObject(Employee employee);
        Employee UpdateObject(Employee employee);
        Employee SoftDeleteObject(Employee employee);
        bool DeleteObject(int Id);
        bool IsNIKDuplicated(Employee employee);
    }
}