using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IEmployeeWorkingTimeRepository : IRepository<EmployeeWorkingTime>
    {
        IQueryable<EmployeeWorkingTime> GetQueryable();
        IList<EmployeeWorkingTime> GetAll();
        EmployeeWorkingTime GetObjectById(int Id);
        EmployeeWorkingTime CreateObject(EmployeeWorkingTime employeeWorkingTime);
        EmployeeWorkingTime UpdateObject(EmployeeWorkingTime employeeWorkingTime);
        EmployeeWorkingTime SoftDeleteObject(EmployeeWorkingTime employeeWorkingTime);
        bool DeleteObject(int Id);
    }
}