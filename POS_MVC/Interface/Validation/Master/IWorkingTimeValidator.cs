﻿using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IWorkingTimeValidator
    {
        
        bool ValidCreateObject(WorkingTime workingTime, IWorkingTimeService _workingTimeService);
        bool ValidUpdateObject(WorkingTime workingTime, IWorkingTimeService _workingTimeService);
        bool ValidDeleteObject(WorkingTime workingTime, IEmployeeWorkingTimeService _employeeWorkingTimeService);
        bool isValid(WorkingTime workingTime);
        string PrintError(WorkingTime workingTime);
        WorkingTime FixWorkingTimeRange(WorkingTime workingTime);
    }
}