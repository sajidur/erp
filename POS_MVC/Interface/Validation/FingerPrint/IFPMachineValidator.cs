﻿using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IFPMachineValidator
    {

        bool ValidCreateObject(FPMachine fpMachine, IFPMachineService _fpMachineService, ICompanyInfoService _companyInfoService);
        bool ValidUpdateObject(FPMachine fpMachine, IFPMachineService _fpMachineService, ICompanyInfoService _companyInfoService);
        bool ValidDeleteObject(FPMachine fpMachine, IFPMachineService _fpMachineService);
        bool ValidConnectObject(FPMachine fpMachine, IFPMachineService _fpMachineService);
        bool ValidDisconnectObject(FPMachine fpMachine, IFPMachineService _fpMachineService);
        bool ValidRefreshObject(FPMachine fpMachine, IFPMachineService _fpMachineService);
        bool ValidSyncObject(FPMachine fpMachine, IFPMachineService _fpMachineService, IFPUserService _fpUserService, IFPTemplateService _fpTemplateService);
        bool isValid(FPMachine fpMachine);
        string PrintError(FPMachine fpMachine);
    }
}