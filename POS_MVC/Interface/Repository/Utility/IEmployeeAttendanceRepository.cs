using Data.Repository;
using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IEmployeeAttendanceRepository : IRepository<EmployeeAttendance>
    {
        IQueryable<EmployeeAttendance> GetQueryable();
        IList<EmployeeAttendance> GetAll(int year, int month);
        List<EmployeeAttendance> GetAttendanceCount(int year,int month);
        EmployeeAttendance GetObjectById(int Id);
        EmployeeAttendance CreateObject(EmployeeAttendance employeeAttendance);
        EmployeeAttendance UpdateObject(EmployeeAttendance employeeAttendance);
        EmployeeAttendance SoftDeleteObject(EmployeeAttendance employeeAttendance);
        bool DeleteObject(int Id);
    }
}