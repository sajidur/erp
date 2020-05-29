using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Repository;
using System.Data;
using System.Data.Entity;
using RexERP_MVC.Models;

namespace Data.Repository
{
    public class EmployeeAttendanceRepository : EfRepository<EmployeeAttendance>, IEmployeeAttendanceRepository
    {
        private Entities entities;
        public EmployeeAttendanceRepository()
        {
            entities = new Entities();
        }

        public IQueryable<EmployeeAttendance> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }
        public List<EmployeeAttendance> GetAttendanceCount(int year,int month)
        {
            var results = from p in entities.EmployeeAttendances where p.AttendanceDate.Month==month && p.AttendanceDate.Year==year
                          select p;
            return results.ToList();
            
        }

        public EmployeeAttendance GetObjectById(int Id)
        {
            EmployeeAttendance employeeAttendance = Find(x => x.Id == Id && !x.IsDeleted);
            return employeeAttendance;
        }

        public EmployeeAttendance CreateObject(EmployeeAttendance employeeAttendance)
        {
            employeeAttendance.IsDeleted = false;
            employeeAttendance.CreatedAt = DateTime.Now;
            return Create(employeeAttendance);
        }

        public EmployeeAttendance UpdateObject(EmployeeAttendance employeeAttendance)
        {
            employeeAttendance.UpdatedAt = DateTime.Now;
            Update(employeeAttendance);
            return employeeAttendance;
        }

        public EmployeeAttendance SoftDeleteObject(EmployeeAttendance employeeAttendance)
        {
            employeeAttendance.IsDeleted = true;
            employeeAttendance.DeletedAt = DateTime.Now;
            Update(employeeAttendance);
            return employeeAttendance;
        }

        public bool DeleteObject(int Id)
        {
            EmployeeAttendance employeeAttendance = Find(x => x.Id == Id);
            return (Delete(employeeAttendance) == 1) ? true : false;
        }

        public IList<EmployeeAttendance> GetAll(int year, int month)
        {
            return FindAll(x => !x.IsDeleted && x.AttendanceDate.Year==year && x.AttendanceDate.Month==month).ToList();
        }
    }
    public class EmployeeCountGroupResponse
    {
        public int EmployeeId { get; set; }
        public int Count { get; set; }
    }
}