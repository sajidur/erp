﻿using RexERP_MVC.Models;
using System.Collections.Generic;

namespace RexERP_MVC.BAL
{
    public class PictureService
    {
        DBService<Picture> service = new DBService<Picture>();
        public List<Picture> GetAll()
        {
            return service.GetAll();
        }
        public Picture GetById(int? id = 0)
        {
            return service.GetById(id);
        }

        public Picture Save(Picture cus)
        {
            return service.Save(cus);

        }
        public Picture Update(Picture t, int id)
        {
            return service.Update(t, id);

        }
        public int Delete(int id)
        {
            return service.Delete(id);
        }
    }
}