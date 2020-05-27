using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Interface.Validation;
using Data.Repository;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeService = RexERP_MVC.BAL.EmployeeService;

namespace Service.Service
{
    public class EmployeeAttendanceService : IEmployeeAttendanceService
    {
        private IEmployeeAttendanceRepository _repository;
        private IEmployeeAttendanceValidator _validator;
        public EmployeeAttendanceService(IEmployeeAttendanceRepository _employeeAttendanceRepository, IEmployeeAttendanceValidator _employeeAttendanceValidator)
        {
            _repository = _employeeAttendanceRepository;
            _validator = _employeeAttendanceValidator;
        }

        public IEmployeeAttendanceValidator GetValidator()
        {
            return _validator;
        }

        public IQueryable<EmployeeAttendance> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public IList<EmployeeAttendance> GetAll()
        {
            return _repository.GetAll();
        }
        public List<EmployeeCountGroupResponse> GetAttendanceCount(int month)
        {
            return _repository.GetAttendanceCount(month);
        }

        public EmployeeAttendance GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public EmployeeAttendance CreateObject(EmployeeAttendance employeeAttendance, EmployeeService _employeeService)
        {
            _repository.CreateObject(employeeAttendance);
            return employeeAttendance;
        }

        public EmployeeAttendance UpdateObject(EmployeeAttendance employeeAttendance, EmployeeService _employeeService)
        {
            _repository.UpdateObject(employeeAttendance);
            return employeeAttendance;
        }

        public EmployeeAttendance SoftDeleteObject(EmployeeAttendance employeeAttendance)
        {
            return (employeeAttendance = _validator.ValidDeleteObject(employeeAttendance) ?
                    _repository.SoftDeleteObject(employeeAttendance) : employeeAttendance);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }

    }
}