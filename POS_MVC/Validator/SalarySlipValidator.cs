﻿using Core.Interface.Validation;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;


namespace Validation.Validation
{
    public class SalarySlipValidator : ISalarySlipValidator
    {
        public SalarySlip VHasUniqueCode(SalarySlip salarySlip, ISalarySlipService _salarySlipService)
        {
            //if (String.IsNullOrEmpty(salarySlip.Code) || salarySlip.Code.Trim() == "")
            //{
            //    salarySlip.Errors.Add("Code", "Tidak boleh kosong");
            //}
            //else if (_salarySlipService.IsCodeDuplicated(salarySlip))
            //{
            //    salarySlip.Errors.Add("Code", "Tidak boleh ada duplikasi");
            //}
            return salarySlip;
        }

        public SalarySlip VHasSalaryItem(SalarySlip salarySlip, ISalaryItemService _salaryItemService)
        {
            SalaryItem salaryItem = _salaryItemService.GetObjectById(salarySlip.SalaryItemId.GetValueOrDefault());
            //if (salaryItem == null)
            //{
            //    salarySlip.Errors.Add("SalaryItem", "Tidak ada");
            //}
            return salarySlip;
        }

        public SalarySlip VHasValidSign(SalarySlip salarySlip)
        {
            //if (salarySlip.SalarySign == 0)
            //{
            //    salarySlip.Errors.Add("SalarySign", "Tidak valid");
            //}
            return salarySlip;
        }

        public bool ValidCreateObject(SalarySlip salarySlip, ISalarySlipService _salarySlipService, ISalaryItemService _salaryItemService)
        {
            VHasUniqueCode(salarySlip, _salarySlipService);
            if (!isValid(salarySlip)) { return false; }
            VHasSalaryItem(salarySlip, _salaryItemService);
            if (!isValid(salarySlip)) { return false; }
            VHasValidSign(salarySlip);
            return isValid(salarySlip);
        }

        public bool ValidUpdateObject(SalarySlip salarySlip, ISalarySlipService _salarySlipService, ISalaryItemService _salaryItemService)
        {
            //salarySlip.Errors.Clear();
            ValidCreateObject(salarySlip, _salarySlipService, _salaryItemService);
            return isValid(salarySlip);
        }

        public bool ValidDeleteObject(SalarySlip salarySlip)
        {
            //salarySlip.Errors.Clear();
            return isValid(salarySlip);
        }

        public bool isValid(SalarySlip obj)
        {
            //bool isValid = !obj.Errors.Any();
            return true;
        }

        public string PrintError(SalarySlip obj)
        {
            string erroroutput = "";
            //KeyValuePair<string, string> first = obj.Errors.ElementAt(0);
            //erroroutput += first.Key + "," + first.Value;
            //foreach (KeyValuePair<string, string> pair in obj.Errors.Skip(1))
            //{
            //    erroroutput += Environment.NewLine;
            //    erroroutput += pair.Key + "," + pair.Value;
            //}
            return erroroutput;
        }

    }
}
