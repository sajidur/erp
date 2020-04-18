﻿using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IWorkingDayRepository : IRepository<WorkingDay>
    {
        IQueryable<WorkingDay> GetQueryable();
        IList<WorkingDay> GetAll();
        WorkingDay GetObjectById(int Id);
        WorkingDay GetObjectByCode(string code);
        WorkingDay CreateObject(WorkingDay workingDay);
        WorkingDay UpdateObject(WorkingDay workingDay);
        WorkingDay SoftDeleteObject(WorkingDay workingDay);
        bool DeleteObject(int Id);
    }
}