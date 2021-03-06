﻿using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class CategoryService
    {
        DBService<Category> service = new DBService<Category>();
        public List<Category> GetAll()
        {
            return service.GetAll(a=>a.IsActive==true).ToList();
        }
        public Category GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public Category Save(Category cus)
        {
            var isExists = service.GetAll().Where(a => a.CategoryName == cus.CategoryName || a.Code==cus.Code).FirstOrDefault();
            if (isExists !=null)
            {
                return null;
            }
            service.Save(cus);
            return cus;

        }
        public Category Update(Category t, int id)
        {
          return  service.Update(t, id);
        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }

    }
}