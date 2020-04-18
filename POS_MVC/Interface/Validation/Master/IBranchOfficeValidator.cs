using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IBranchOfficeValidator
    {
        BranchOffice VHasUniqueName(BranchOffice branchOffice, IBranchOfficeService _branchOfficeService);

        bool ValidCreateObject(BranchOffice branchOffice, IBranchOfficeService _branchOfficeService, ICompanyInfoService _companyInfoService);
        bool ValidUpdateObject(BranchOffice branchOffice, IBranchOfficeService _branchOfficeService, ICompanyInfoService _companyInfoService);
        bool isValid(BranchOffice branchOffice);
        string PrintError(BranchOffice branchOffice);
    }
}