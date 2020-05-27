using Core.Interface.Repository;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class SalaryItemRepository : EfRepository<PayHead>
    {
        private Entities entities;
        public SalaryItemRepository()
        {
            entities = new Entities();
        }

        public IQueryable<PayHead> GetQueryable()
        {
            return FindAll(x => !x.Active);
        }

        public IList<PayHead> GetAll()
        {
            return FindAll(x => !x.Active).ToList();
        }

        public PayHead GetObjectById(int Id)
        {
            PayHead salaryItem = Find(x => x.Id == Id && !x.Active);
           // if (salaryItem != null) { salaryItem.Errors = new Dictionary<string, string>(); }
            return salaryItem;
        }
      
        public bool DeleteObject(int Id)
        {
            PayHead salaryItem = Find(x => x.Id == Id);
            return (Delete(salaryItem) == 1) ? true : false;
        }

        public bool IsCodeDuplicated(PayHead salaryItem)
        {
            IQueryable<PayHead> salaryItems = FindAll(x=>!x.Active && x.Id != salaryItem.Id);
            return (salaryItems.Count() > 0 ? true : false);
        }
    }
}