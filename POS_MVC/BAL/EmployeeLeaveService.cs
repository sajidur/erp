using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Interface.Validation;
using RexERP_MVC.Models;
using RexERP_MVC.BAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Service
{
    public class EmployeeLeaveService : IEmployeeLeaveService
    {
        private IEmployeeLeaveRepository _repository;
        private IEmployeeLeaveValidator _validator;
        public EmployeeLeaveService(IEmployeeLeaveRepository _employeeLeaveRepository, IEmployeeLeaveValidator _employeeLeaveValidator)
        {
            _repository = _employeeLeaveRepository;
            _validator = _employeeLeaveValidator;
        }

        public IEmployeeLeaveValidator GetValidator()
        {
            return _validator;
        }

        public IQueryable<EmployeeLeave> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public IList<EmployeeLeave> GetAll()
        {
            return _repository.GetAll();
        }
        public IList<EmployeeLeave> GetAll(List<int> employeeIds)
        {
            return _repository.GetAll(employeeIds);
        }
        public EmployeeLeave GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public EmployeeLeave CreateObject(EmployeeLeave employeeLeave, EmployeeService _employeeService)
        {
            employeeLeave.LeaveInterval = (int)employeeLeave.EndDate.Subtract(employeeLeave.StartDate).TotalDays + 1;
            _repository.CreateObject(employeeLeave);
            return employeeLeave;
        }

        public EmployeeLeave UpdateObject(EmployeeLeave employeeLeave, EmployeeService _employeeService)
        {
            if (_validator.ValidUpdateObject(employeeLeave, _employeeService))
            {
                employeeLeave.LeaveInterval = (int)employeeLeave.EndDate.Subtract(employeeLeave.StartDate).TotalDays + 1;
                _repository.UpdateObject(employeeLeave);
            }
            return employeeLeave;
        }

        public EmployeeLeave SoftDeleteObject(EmployeeLeave employeeLeave)
        {
            return (employeeLeave = _validator.ValidDeleteObject(employeeLeave) ?
                    _repository.SoftDeleteObject(employeeLeave) : employeeLeave);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }

        
    }
}