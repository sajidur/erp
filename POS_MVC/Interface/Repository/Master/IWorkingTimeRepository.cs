using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IWorkingTimeRepository : IRepository<WorkingTime>
    {
        IQueryable<WorkingTime> GetQueryable();
        IList<WorkingTime> GetAll();
        WorkingTime GetObjectById(int Id);
        WorkingTime GetObjectByCode(string code);
        WorkingTime CreateObject(WorkingTime workingTime);
        WorkingTime UpdateObject(WorkingTime workingTime);
        WorkingTime SoftDeleteObject(WorkingTime workingTime);
        bool DeleteObject(int Id);
    }
}