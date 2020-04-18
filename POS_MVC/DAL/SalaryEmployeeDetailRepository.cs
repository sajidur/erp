﻿using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RexERP_MVC.Models;

namespace Data.Repository
{
    public class SalaryEmployeeDetailRepository : EfRepository<SalaryEmployeeDetail>, ISalaryEmployeeDetailRepository
    {
        private Entities entities;
        public SalaryEmployeeDetailRepository()
        {
            entities = new Entities();
        }

        public IQueryable<SalaryEmployeeDetail> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<SalaryEmployeeDetail> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public SalaryEmployeeDetail GetObjectById(int Id)
        {
            SalaryEmployeeDetail salaryEmployeeDetail = FindAll(x => x.Id == Id && !x.IsDeleted).Include("SalaryEmployee").Include("SalaryItem").FirstOrDefault();
           // if (salaryEmployeeDetail != null) { salaryEmployeeDetail.Errors = new Dictionary<string, string>(); }
            return salaryEmployeeDetail;
        }

        public SalaryEmployeeDetail CreateObject(SalaryEmployeeDetail salaryEmployeeDetail)
        {
            salaryEmployeeDetail.IsDeleted = false;
            salaryEmployeeDetail.CreatedAt = DateTime.Now;
            return Create(salaryEmployeeDetail);
        }

        public SalaryEmployeeDetail UpdateObject(SalaryEmployeeDetail salaryEmployeeDetail)
        {
            salaryEmployeeDetail.UpdatedAt = DateTime.Now;
            Update(salaryEmployeeDetail);
            return salaryEmployeeDetail;
        }

        public SalaryEmployeeDetail SoftDeleteObject(SalaryEmployeeDetail salaryEmployeeDetail)
        {
            salaryEmployeeDetail.IsDeleted = true;
            salaryEmployeeDetail.DeletedAt = DateTime.Now;
            Update(salaryEmployeeDetail);
            return salaryEmployeeDetail;
        }

        public bool DeleteObject(int Id)
        {
            SalaryEmployeeDetail salaryEmployeeDetail = Find(x => x.Id == Id);
            return (Delete(salaryEmployeeDetail) == 1) ? true : false;
        }

        
    }
}