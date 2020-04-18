using Core.Interface.Repository;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class SalaryStandardRepository : EfRepository<SalaryStandard>, ISalaryStandardRepository
    {
        private Entities entities;
        public SalaryStandardRepository()
        {
            entities = new Entities();
        }

        public IQueryable<SalaryStandard> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<SalaryStandard> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public SalaryStandard GetObjectById(int Id)
        {
            SalaryStandard salaryStandard = Find(x => x.Id == Id && !x.IsDeleted);
          //  if (salaryStandard != null) { salaryStandard.Errors = new Dictionary<string, string>(); }
            return salaryStandard;
        }

        public SalaryStandard CreateObject(SalaryStandard salaryStandard)
        {
            salaryStandard.IsDeleted = false;
            salaryStandard.CreatedAt = DateTime.Now;
            return Create(salaryStandard);
        }

        public SalaryStandard UpdateObject(SalaryStandard salaryStandard)
        {
            salaryStandard.UpdatedAt = DateTime.Now;
            Update(salaryStandard);
            return salaryStandard;
        }

        public SalaryStandard SoftDeleteObject(SalaryStandard salaryStandard)
        {
            salaryStandard.IsDeleted = true;
            salaryStandard.DeletedAt = DateTime.Now;
            Update(salaryStandard);
            return salaryStandard;
        }

        public bool DeleteObject(int Id)
        {
            SalaryStandard salaryStandard = Find(x => x.Id == Id);
            return (Delete(salaryStandard) == 1) ? true : false;
        }

        
    }
}