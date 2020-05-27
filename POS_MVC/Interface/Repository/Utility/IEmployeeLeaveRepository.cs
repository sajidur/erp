using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IEmployeeLeaveRepository : IRepository<EmployeeLeave>
    {
        IQueryable<EmployeeLeave> GetQueryable();
        IList<EmployeeLeave> GetAll();
        IList<EmployeeLeave> GetAll(List<int> employeeIds);

        EmployeeLeave GetObjectById(int Id);
        EmployeeLeave CreateObject(EmployeeLeave employeeLeave);
        EmployeeLeave UpdateObject(EmployeeLeave employeeLeave);
        EmployeeLeave SoftDeleteObject(EmployeeLeave employeeLeave);
        bool DeleteObject(int Id);
    }
}