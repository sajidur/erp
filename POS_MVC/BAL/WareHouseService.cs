﻿using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class WareHouseService
    {
        DBService<WareHouse> service = new DBService<WareHouse>();
        public List<WareHouse> GetAll()
        {
            //return service.GetAll();
            return service.GetAll(a => a.IsActive == true).ToList();
        }
        public WareHouse GetById(int? id = 0)
        {
            return service.GetById(id);
        }
        public WareHouse GetByUserId(int UserId)
        {
            return service.GetAll(a => a.UserId == UserId).FirstOrDefault();
        }
        public WareHouse Save(WareHouse cus)
        {
            return service.Save(cus);

        }
        public WareHouse Update(WareHouse t, int id)
        {
            return service.Update(t, id);

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}