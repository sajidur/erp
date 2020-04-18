using Core.Interface.Repository;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class LastEmploymentRepository : EfRepository<LastEmployment>, ILastEmploymentRepository
    {
        private Entities entities;
        public LastEmploymentRepository()
        {
            entities = new Entities();
        }

        public IQueryable<LastEmployment> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<LastEmployment> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public LastEmployment GetObjectById(int Id)
        {
            LastEmployment lastEmployment = Find(x => x.Id == Id && !x.IsDeleted);
           // if (lastEmployment != null) { lastEmployment.Errors = new Dictionary<string, string>(); }
            return lastEmployment;
        }

        public LastEmployment CreateObject(LastEmployment lastEmployment)
        {
            lastEmployment.IsDeleted = false;
            lastEmployment.CreatedAt = DateTime.Now;
            return Create(lastEmployment);
        }

        public LastEmployment UpdateObject(LastEmployment lastEmployment)
        {
            lastEmployment.UpdatedAt = DateTime.Now;
            Update(lastEmployment);
            return lastEmployment;
        }

        public LastEmployment SoftDeleteObject(LastEmployment lastEmployment)
        {
            lastEmployment.IsDeleted = true;
            lastEmployment.DeletedAt = DateTime.Now;
            Update(lastEmployment);
            return lastEmployment;
        }

        public bool DeleteObject(int Id)
        {
            LastEmployment lastEmployment = Find(x => x.Id == Id);
            return (Delete(lastEmployment) == 1) ? true : false;
        }

        
    }
}