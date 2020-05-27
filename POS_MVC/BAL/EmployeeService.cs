using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class EmployeeService
    {
        DBService<Employee> service = new DBService<Employee>();
        public List<Employee> GetAll()
        {
            return service.GetAll(a => a.IsActive == true).ToList();
        }
        public List<Employee> GetAll(int designationId)
        {
            return service.GetAll(a => a.IsActive == true).ToList();
        }
        public List<Employee> GetAll(string name)
        {
            return service.GetAll(a => a.FirstName == name).ToList();
        }
        public Employee GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        internal Employee GetObjectById(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Employee Save(Employee cus)
        {
            cus.CreationDate = DateTime.Now;
            return service.Save(cus);

        }
        public Employee Update(Employee t, int id)
        {
            return service.Update(t, id);

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }

        internal IList<Employee> GetObjectsByTitleInfoId(int id)
        {
            throw new NotImplementedException();
        }
    }
}