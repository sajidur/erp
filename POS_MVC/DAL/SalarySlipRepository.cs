﻿using Core.Interface.Repository;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class SalarySlipRepository : EfRepository<SalarySlip>, ISalarySlipRepository
    {
        private Entities entities;
        public SalarySlipRepository()
        {
            entities = new Entities();
        }

        public IQueryable<SalarySlip> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<SalarySlip> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public SalarySlip GetObjectById(int Id)
        {
            SalarySlip salarySlip = Find(x => x.Id == Id && !x.IsDeleted);
           // if (salarySlip != null) { salarySlip.Errors = new Dictionary<string, string>(); }
            return salarySlip;
        }

        public SalarySlip CreateObject(SalarySlip salarySlip)
        {
            salarySlip.IsDeleted = false;
            salarySlip.CreatedAt = DateTime.Now;
            return Create(salarySlip);
        }

        public SalarySlip UpdateObject(SalarySlip salarySlip)
        {
            salarySlip.UpdatedAt = DateTime.Now;
            Update(salarySlip);
            return salarySlip;
        }

        public SalarySlip SoftDeleteObject(SalarySlip salarySlip)
        {
            salarySlip.IsDeleted = true;
            salarySlip.DeletedAt = DateTime.Now;
            Update(salarySlip);
            return salarySlip;
        }

        public bool DeleteObject(int Id)
        {
            SalarySlip salarySlip = Find(x => x.Id == Id);
            return (Delete(salarySlip) == 1) ? true : false;
        }

        
    }
}