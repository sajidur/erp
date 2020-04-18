using Core.Interface.Validation;
using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Validation.Validation
{
    public class CompanyInfoValidator : ICompanyInfoValidator
    {
        public CompanyInfo VHasUniqueName(CompanyInfo companyInfo, ICompanyInfoService _companyInfoService)
        {
            return companyInfo;
        }

        public CompanyInfo VHasAddress(CompanyInfo companyInfo)
        {
            return companyInfo;
        }

        public CompanyInfo VHasPhoneNumber(CompanyInfo companyInfo)
        {
            return companyInfo;
        }

        public CompanyInfo VHasEmail(CompanyInfo companyInfo)
        {
            return companyInfo;
        }

        public bool ValidCreateObject(CompanyInfo companyInfo, ICompanyInfoService _companyInfoService)
        {
            VHasUniqueName(companyInfo, _companyInfoService);
            if (!isValid(companyInfo)) { return false; }
            VHasAddress(companyInfo);
            if (!isValid(companyInfo)) { return false; }
            VHasPhoneNumber(companyInfo);
            if (!isValid(companyInfo)) { return false; }
            VHasEmail(companyInfo);
            return isValid(companyInfo);
        }

        public bool ValidUpdateObject(CompanyInfo companyInfo, ICompanyInfoService _companyInfoService)
        {
            return ValidCreateObject(companyInfo, _companyInfoService);
        }

        public bool ValidDeleteObject(CompanyInfo companyInfo, IBranchOfficeService _branchOfficeService)
        {
            //VDontHaveBranchOffices(companyInfo, _branchOfficeService);
            return isValid(companyInfo);
        }

        public bool isValid(CompanyInfo obj)
        {
            return true;
        }

        public string PrintError(CompanyInfo obj)
        {
            string erroroutput = "";
            return erroroutput;
        }

    }
}
