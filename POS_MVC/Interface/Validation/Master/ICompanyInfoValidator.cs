using Core.Interface.Service;
using RexERP_MVC.Models;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface ICompanyInfoValidator
    {
        CompanyInfo VHasUniqueName(CompanyInfo companyInfo, ICompanyInfoService _companyInfoService);
        CompanyInfo VHasAddress(CompanyInfo companyInfo);
        CompanyInfo VHasPhoneNumber(CompanyInfo companyInfo);
        CompanyInfo VHasEmail(CompanyInfo companyInfo);
        
        bool ValidCreateObject(CompanyInfo companyInfo, ICompanyInfoService _companyInfoService);
        bool ValidUpdateObject(CompanyInfo companyInfo, ICompanyInfoService _companyInfoService);
        bool ValidDeleteObject(CompanyInfo companyInfo, IBranchOfficeService _branchOfficeService);
        bool isValid(CompanyInfo companyInfo);
        string PrintError(CompanyInfo companyInfo);
    }
}