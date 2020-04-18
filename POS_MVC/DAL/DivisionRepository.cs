using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;

namespace Data.Repository
{
    public class DivisionRepository : EfRepository<Division>, IDivisionRepository
    {
        private Entities entities;
        public DivisionRepository()
        {
            entities = new Entities();
        }

        public IQueryable<Division> GetQueryable()
        {
            return FindAll(x => !x.IsDeleted);
        }

        public IList<Division> GetAll()
        {
            return FindAll(x => !x.IsDeleted).ToList();
        }

        public Division GetObjectById(int Id)
        {
            Division division = Find(x => x.Id == Id && !x.IsDeleted);
            return division;
        }

        public Division GetObjectByName(string Name)
        {
            return FindAll(x => x.Name == Name && !x.IsDeleted).FirstOrDefault();
        }

        public Division CreateObject(Division division)
        {
            division.IsDeleted = false;
            division.CreatedAt = DateTime.Now;
            return Create(division);
        }

        public Division UpdateObject(Division division)
        {
            division.UpdatedAt = DateTime.Now;
            Update(division);
            return division;
        }

        public Division SoftDeleteObject(Division division)
        {
            division.IsDeleted = true;
            division.DeletedAt = DateTime.Now;
            Update(division);
            return division;
        }

        public bool DeleteObject(int Id)
        {
            Division division = Find(x => x.Id == Id);
            return (Delete(division) == 1) ? true : false;
        }

        public bool IsNameDuplicated(Division division)
        {
            IQueryable<Division> divisions = FindAll(x => x.Name == division.Name && !x.IsDeleted && x.Id != division.Id);
            return (divisions.Count() > 0 ? true : false);
        }
    }
}