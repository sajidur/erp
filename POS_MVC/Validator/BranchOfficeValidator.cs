﻿using Core.Interface.Validation;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;

namespace Validation.Validation
{
    public class BranchOfficeValidator : IBranchOfficeValidator
    {
        public BranchOffice VHasCompany(BranchOffice branchOffice, ICompanyInfoService _companyInfoService)
        {
            CompanyInfo companyInfo = _companyInfoService.GetObjectById(branchOffice.CompanyInfoId.GetValueOrDefault());
            if (companyInfo == null)
            {
              //  branchOffice.Errors.Add("Generic", "Company Tidak valid");
            }
            return branchOffice;
        }

        public BranchOffice VHasUniqueCode(BranchOffice branchOffice, IBranchOfficeService _branchOfficeService)
        {
            if (String.IsNullOrEmpty(branchOffice.Code) || branchOffice.Code.Trim() == "")
            {
              //  branchOffice.Errors.Add("Code", "Tidak boleh kosong");
            }
            else if (_branchOfficeService.IsCodeDuplicated(branchOffice))
            {
               // branchOffice.Errors.Add("Code", "Tidak boleh ada duplikasi");
            }
            return branchOffice;
        }

        public BranchOffice VHasUniqueName(BranchOffice branchOffice, IBranchOfficeService _branchOfficeService)
        {
            if (String.IsNullOrEmpty(branchOffice.Name) || branchOffice.Name.Trim() == "")
            {
              //  branchOffice.Errors.Add("Name", "Tidak boleh kosong");
            }
            else if (_branchOfficeService.IsNameDuplicated(branchOffice))
            {
               // branchOffice.Errors.Add("Name", "Tidak boleh ada duplikasi");
            }
            return branchOffice;
        }

        public BranchOffice VHasAddress(BranchOffice branchOffice)
        {
            if (String.IsNullOrEmpty(branchOffice.Address) || branchOffice.Address.Trim() == "")
            {
              //  branchOffice.Errors.Add("Address", "Tidak boleh kosong");
            }
            return branchOffice;
        }

        public BranchOffice VHasPhoneNumber(BranchOffice branchOffice)
        {
            if (String.IsNullOrEmpty(branchOffice.PhoneNumber) || branchOffice.PhoneNumber.Trim() == "")
            {
              //  branchOffice.Errors.Add("PhoneNumber", "Tidak boleh kosong");
            }
            return branchOffice;
        }

        public BranchOffice VHasEmail(BranchOffice branchOffice)
        {
            if (String.IsNullOrEmpty(branchOffice.Email) || branchOffice.Email.Trim() == "")
            {
              //  branchOffice.Errors.Add("Email", "Tidak boleh kosong");
            }
            return branchOffice;
        }
        public bool ValidCreateObject(BranchOffice branchOffice, IBranchOfficeService _branchOfficeService, ICompanyInfoService _companyInfoService)
        {
            VHasCompany(branchOffice, _companyInfoService);
            if (!isValid(branchOffice)) { return false; }
            VHasUniqueCode(branchOffice, _branchOfficeService);
            if (!isValid(branchOffice)) { return false; }
            VHasUniqueName(branchOffice, _branchOfficeService);
            if (!isValid(branchOffice)) { return false; }
            VHasAddress(branchOffice);
            if (!isValid(branchOffice)) { return false; }
            VHasPhoneNumber(branchOffice);
            if (!isValid(branchOffice)) { return false; }
            VHasEmail(branchOffice);
            return isValid(branchOffice);
        }

        public bool ValidUpdateObject(BranchOffice branchOffice, IBranchOfficeService _branchOfficeService, ICompanyInfoService _companyInfoService)
        {
           // branchOffice.Errors.Clear();
            return ValidCreateObject(branchOffice, _branchOfficeService, _companyInfoService);
        }

    

        public bool isValid(BranchOffice obj)
        {
           // bool isValid = !obj.Errors.Any();
            return true;
        }

        public string PrintError(BranchOffice obj)
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
