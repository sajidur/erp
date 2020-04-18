﻿using Core.Interface.Repository;
using RexERP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class PPH21SPTRepository : EfRepository<PPH21SPT>, IPPH21SPTRepository
    {
        private Entities entities;
        public PPH21SPTRepository()
        {
            entities = new Entities();
        }

        public IQueryable<PPH21SPT> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<PPH21SPT> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public PPH21SPT GetObjectById(int Id)
        {
            PPH21SPT pph21spt = Find(x => x.Id == Id && !x.IsDeleted);
            //if (pph21spt != null) { pph21spt.Errors = new Dictionary<string, string>(); }
            return pph21spt;
        }

        public PPH21SPT GetObjectBySalary(decimal Amount)
        {
            PPH21SPT pph21spt = Find(x => x.MinAmount <= Amount && (x.IsInfiniteMaxAmount || x.MaxAmount >= Amount) && !x.IsDeleted);
           // if (pph21spt != null) { pph21spt.Errors = new Dictionary<string, string>(); }
            return pph21spt;
        }

        public PPH21SPT CreateObject(PPH21SPT pph21spt)
        {
            pph21spt.IsDeleted = false;
            pph21spt.CreatedAt = DateTime.Now;
            return Create(pph21spt);
        }

        public PPH21SPT UpdateObject(PPH21SPT pph21spt)
        {
            pph21spt.UpdatedAt = DateTime.Now;
            Update(pph21spt);
            return pph21spt;
        }

        public PPH21SPT SoftDeleteObject(PPH21SPT pph21spt)
        {
            pph21spt.IsDeleted = true;
            pph21spt.DeletedAt = DateTime.Now;
            Update(pph21spt);
            return pph21spt;
        }

        public bool DeleteObject(int Id)
        {
            PPH21SPT pph21spt = Find(x => x.Id == Id);
            return (Delete(pph21spt) == 1) ? true : false;
        }

        
    }
}