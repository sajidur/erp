using Core.Interface.Service;
using RexERP_MVC.Models;

namespace Core.Interface.Validation
{
    public interface IWorkingDayValidator
    {

        bool ValidCreateObject(WorkingDay workingDay, IWorkingTimeService _workingTimeService);
        bool ValidUpdateObject(WorkingDay workingDay, IWorkingTimeService _workingTimeService);
        bool ValidDeleteObject(WorkingDay workingDay);
        bool isValid(WorkingDay workingDay);
        string PrintError(WorkingDay workingDay);
        WorkingDay FixWorkingDayRange(WorkingDay workingDay);
    }
}