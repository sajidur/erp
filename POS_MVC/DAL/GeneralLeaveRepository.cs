using RexERP_MVC.Models;
using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Repository;
using System.Data;
using System.Data.Entity;

namespace Data.Repository
{
    public class GeneralLeaveRepository : EfRepository<GeneralLeave>, IGeneralLeaveRepository
    {
        private Entities entities;
        public GeneralLeaveRepository()
        {
            entities = new Entities();
        }

        public IQueryable<GeneralLeave> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<GeneralLeave> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public GeneralLeave GetObjectById(int Id)
        {
            GeneralLeave generalLeave = Find(x => x.Id == Id && !x.IsDeleted);
            return generalLeave;
        }

        public GeneralLeave CreateObject(GeneralLeave generalLeave)
        {
            generalLeave.IsDeleted = false;
            generalLeave.CreatedAt = DateTime.Now;
            return Create(generalLeave);
        }

        public GeneralLeave UpdateObject(GeneralLeave generalLeave)
        {
            generalLeave.UpdatedAt = DateTime.Now;
            Update(generalLeave);
            return generalLeave;
        }

        public GeneralLeave SoftDeleteObject(GeneralLeave generalLeave)
        {
            generalLeave.IsDeleted = true;
            generalLeave.DeletedAt = DateTime.Now;
            Update(generalLeave);
            return generalLeave;
        }

        public bool DeleteObject(int Id)
        {
            GeneralLeave generalLeave = Find(x => x.Id == Id);
            return (Delete(generalLeave) == 1) ? true : false;
        }


    }
}