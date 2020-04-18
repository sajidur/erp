using RexERP_MVC.Models;
using Core.Interface.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Service
{
    public interface IGeneralLeaveService
    {
        IGeneralLeaveValidator GetValidator();
        IQueryable<GeneralLeave> GetQueryable();
        IList<GeneralLeave> GetAll();
        GeneralLeave GetObjectById(int Id);
        GeneralLeave CreateObject(GeneralLeave generalLeave);
        GeneralLeave UpdateObject(GeneralLeave generalLeave);
        GeneralLeave SoftDeleteObject(GeneralLeave generalLeave);
        bool DeleteObject(int Id);
    }
}