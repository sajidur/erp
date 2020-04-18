﻿using Core.Interface.Validation;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;
using RexERP_MVC.BAL;

namespace Validation.Validation
{
    public class TitleInfoValidator : ITitleInfoValidator
    {

        public TitleInfo VHasUniqueCode(TitleInfo titleInfo, ITitleInfoService _titleInfoService)
        {
            //if (String.IsNullOrEmpty(titleInfo.Code) || titleInfo.Code.Trim() == "")
            //{
            //    titleInfo.Errors.Add("Code", "Tidak boleh kosong");
            //}
            //else if (_titleInfoService.IsCodeDuplicated(titleInfo))
            //{
            //    titleInfo.Errors.Add("Code", "Tidak boleh ada duplikasi");
            //}
            return titleInfo;
        }

        public TitleInfo VHasName(TitleInfo titleInfo)
        {
            //if (String.IsNullOrEmpty(titleInfo.Name) || titleInfo.Name.Trim() == "")
            //{
            //    titleInfo.Errors.Add("Name", "Tidak boleh kosong");
            //}
            return titleInfo;
        }

        public TitleInfo VDontHaveEmployees(TitleInfo titleInfo, EmployeeService _employeeService)
        {
            IList<Employee> employees = _employeeService.GetObjectsByTitleInfoId(titleInfo.Id);
            //if (employees.Any())
            //{
            //    titleInfo.Errors.Add("Generic", "Tidak boleh masih terasosiasi dengan Employees");
            //}
            return titleInfo;
        }

        public bool ValidCreateObject(TitleInfo titleInfo, ITitleInfoService _titleInfoService)
        {
            VHasUniqueCode(titleInfo, _titleInfoService);
            if (!isValid(titleInfo)) { return false; }
            VHasName(titleInfo);
            return isValid(titleInfo);
        }

        public bool ValidUpdateObject(TitleInfo titleInfo, ITitleInfoService _titleInfoService)
        {
            //titleInfo.Errors.Clear();
            ValidCreateObject(titleInfo, _titleInfoService);
            return isValid(titleInfo);
        }

        public bool ValidDeleteObject(TitleInfo titleInfo, EmployeeService _employeeService)
        {
            //titleInfo.Errors.Clear();
            VDontHaveEmployees(titleInfo, _employeeService);
            return isValid(titleInfo);
        }

        public bool isValid(TitleInfo obj)
        {
            //bool isValid = !obj.Errors.Any();
            return true;
        }

        public string PrintError(TitleInfo obj)
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
