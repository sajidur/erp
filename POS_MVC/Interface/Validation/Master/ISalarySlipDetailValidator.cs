﻿using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ISalarySlipDetailValidator
    {

        bool ValidCreateObject(SalarySlipDetail salarySlipDetail, ISalarySlipService _salarySlipService, IFormulaService _formulaService);
        bool ValidUpdateObject(SalarySlipDetail salarySlipDetail, ISalarySlipService _salarySlipService, IFormulaService _formulaService);
        bool ValidDeleteObject(SalarySlipDetail salarySlipDetail);
        bool isValid(SalarySlipDetail salarySlipDetail);
        string PrintError(SalarySlipDetail salarySlipDetail);
    }
}