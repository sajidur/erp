﻿using RexERP_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Interface.Repository
{
    public interface IPPH21SPTRepository : IRepository<PPH21SPT>
    {
        IQueryable<PPH21SPT> GetQueryable();
        IList<PPH21SPT> GetAll();
        PPH21SPT GetObjectById(int Id);
        PPH21SPT GetObjectBySalary(decimal Amount);
        PPH21SPT CreateObject(PPH21SPT pph21spt);
        PPH21SPT UpdateObject(PPH21SPT pph21spt);
        PPH21SPT SoftDeleteObject(PPH21SPT pph21spt);
        bool DeleteObject(int Id);
    }
}