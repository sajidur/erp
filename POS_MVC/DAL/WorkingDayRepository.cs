﻿using Core.Interface.Repository;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class WorkingDayRepository : EfRepository<WorkingDay>, IWorkingDayRepository
    {
        private Entities entities;
        public WorkingDayRepository()
        {
            entities = new Entities();
        }

        public IQueryable<WorkingDay> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<WorkingDay> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public WorkingDay GetObjectById(int Id)
        {
            WorkingDay workingDay = Find(x => x.Id == Id && !x.IsDeleted);
           // if (workingDay != null) { workingDay.Errors = new Dictionary<string, string>(); }
            return workingDay;
        }

        public WorkingDay GetObjectByCode(string code)
        {
            WorkingDay workingDay = Find(x => x.Code == code && !x.IsDeleted);
           // if (workingDay != null) { workingDay.Errors = new Dictionary<string, string>(); }
            return workingDay;
        }

        public WorkingDay CreateObject(WorkingDay workingDay)
        {
            workingDay.IsDeleted = false;
            workingDay.CreatedAt = DateTime.Now;
            return Create(workingDay);
        }

        public WorkingDay UpdateObject(WorkingDay workingDay)
        {
            workingDay.UpdatedAt = DateTime.Now;
            Update(workingDay);
            return workingDay;
        }

        public WorkingDay SoftDeleteObject(WorkingDay workingDay)
        {
            workingDay.IsDeleted = true;
            workingDay.DeletedAt = DateTime.Now;
            Update(workingDay);
            return workingDay;
        }

        public bool DeleteObject(int Id)
        {
            WorkingDay workingDay = Find(x => x.Id == Id);
            return (Delete(workingDay) == 1) ? true : false;
        }

        
    }
}