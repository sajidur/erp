﻿using Core.Interface.Validation;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;
using RexERP_MVC.BAL;

namespace Validation.Validation
{
    public class LastEmploymentValidator : ILastEmploymentValidator
    {
        public LastEmployment VHasEmployee(LastEmployment lastEmployment, EmployeeService _employeeService)
        {
            Employee employee = _employeeService.GetObjectById(lastEmployment.EmployeeId);
            if (employee == null)
            {
             //   lastEmployment.Errors.Add("Employee", "Tidak valid");
            }
            return lastEmployment;
        }

        public LastEmployment VHasCompany(LastEmployment lastEmployment)
        {
            if (String.IsNullOrEmpty(lastEmployment.Company) || lastEmployment.Company.Trim() == "")
            {
              //  lastEmployment.Errors.Add("Company", "Tidak boleh kosong");
            }
            return lastEmployment;
        }

        public LastEmployment VHasTitle(LastEmployment lastEmployment)
        {
            if (String.IsNullOrEmpty(lastEmployment.Title) || lastEmployment.Title.Trim() == "")
            {
                //lastEmployment.Errors.Add("Title", "Tidak boleh kosong");
            }
            return lastEmployment;
        }

        public LastEmployment VHasReason(LastEmployment lastEmployment)
        {
            if (String.IsNullOrEmpty(lastEmployment.ResignReason) || lastEmployment.ResignReason.Trim() == "")
            {
                //lastEmployment.Errors.Add("ResignReason", "Tidak boleh kosong");
            }
            return lastEmployment;
        }

        public LastEmployment VHasStartDate(LastEmployment lastEmployment)
        {
            if (lastEmployment.StartDate == null || lastEmployment.StartDate.Equals(DateTime.FromBinary(0)))
            {
                //lastEmployment.Errors.Add("StartDate", "Tidak valid");
            }
            return lastEmployment;
        }

        public LastEmployment VHasEndDate(LastEmployment lastEmployment)
        {
            if (lastEmployment.EndDate == null || lastEmployment.EndDate.Equals(DateTime.FromBinary(0)))
            {
               // lastEmployment.Errors.Add("EndDate", "Tidak valid");
            }
            else if (lastEmployment.EndDate.GetValueOrDefault().Date < lastEmployment.StartDate.Date)
            {
              //  lastEmployment.Errors.Add("EndDate", "Harus lebih besar atau sama dengan Start Date");
            }
            return lastEmployment;
        }

        public bool ValidCreateObject(LastEmployment lastEmployment, EmployeeService _employeeService)
        {
            VHasEmployee(lastEmployment, _employeeService);
            if (!isValid(lastEmployment)) { return false; }
            VHasCompany(lastEmployment);
            if (!isValid(lastEmployment)) { return false; }
            VHasTitle(lastEmployment);
            //if (!isValid(lastEmployment)) { return false; }
            //VHasReason(lastEmployment);
            if (!isValid(lastEmployment)) { return false; }
            VHasStartDate(lastEmployment);
            if (!isValid(lastEmployment)) { return false; }
            VHasEndDate(lastEmployment);
            return isValid(lastEmployment);
        }

        public bool ValidUpdateObject(LastEmployment lastEmployment, EmployeeService _employeeService)
        {
           // lastEmployment.Errors.Clear();
            ValidCreateObject(lastEmployment, _employeeService);
            return isValid(lastEmployment);
        }

        public bool ValidDeleteObject(LastEmployment lastEmployment)
        {
          //  lastEmployment.Errors.Clear();
            return isValid(lastEmployment);
        }

        public bool isValid(LastEmployment obj)
        {
          //  bool isValid = !obj.Errors.Any();
            return true;
        }

        public string PrintError(LastEmployment obj)
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
