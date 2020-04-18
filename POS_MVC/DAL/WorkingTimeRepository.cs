using Core.Interface.Repository;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class WorkingTimeRepository : EfRepository<WorkingTime>, IWorkingTimeRepository
    {
        private Entities entities;
        public WorkingTimeRepository()
        {
            entities = new Entities();
        }

        public IQueryable<WorkingTime> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<WorkingTime> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public WorkingTime GetObjectById(int Id)
        {
            WorkingTime workingTime = Find(x => x.Id == Id && !x.IsDeleted);
          //  if (workingTime != null) { workingTime.Errors = new Dictionary<string, string>(); }
            return workingTime;
        }

        public WorkingTime GetObjectByCode(string code)
        {
            WorkingTime workingTime = Find(x => x.Code == code && !x.IsDeleted);
           // if (workingTime != null) { workingTime.Errors = new Dictionary<string, string>(); }
            return workingTime;
        }

        public WorkingTime CreateObject(WorkingTime workingTime)
        {
            workingTime.IsDeleted = false;
            workingTime.CreatedAt = DateTime.Now;
            return Create(workingTime);
        }

        public WorkingTime UpdateObject(WorkingTime workingTime)
        {
            workingTime.UpdatedAt = DateTime.Now;
            Update(workingTime);
            return workingTime;
        }

        public WorkingTime SoftDeleteObject(WorkingTime workingTime)
        {
            workingTime.IsDeleted = true;
            workingTime.DeletedAt = DateTime.Now;
            Update(workingTime);
            return workingTime;
        }

        public bool DeleteObject(int Id)
        {
            WorkingTime workingTime = Find(x => x.Id == Id);
            return (Delete(workingTime) == 1) ? true : false;
        }

        
    }
}