using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interface.Repository;
using RexERP_MVC.Models;
using RexERP_MVC.BAL;

namespace Core.Interface.Service
{
    public interface ISlipGajiMiniService
    {
        ISlipGajiMiniValidator GetValidator();
        ISlipGajiMiniRepository GetRepository();
        IQueryable<SlipGajiMini> GetQueryable();
        IList<SlipGajiMini> GetAll();
        SlipGajiMini GetObjectById(int Id);
        SlipGajiMini GetOrNewObjectByEmployeeMonth(int EmployeeId, DateTime YearMonth);
        SlipGajiMini CreateOrUpdateObject(SlipGajiMini slipGajiMini, EmployeeService _employeeService);
        SlipGajiMini CreateObject(SlipGajiMini slipGajiMini, EmployeeService _employeeService);
        SlipGajiMini UpdateObject(SlipGajiMini slipGajiMini, EmployeeService _employeeService);
        bool DeleteObject(int Id);
    }

}