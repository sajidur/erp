﻿using RexERP_MVC.Models;
using System.Linq;

namespace RexERP_MVC.BAL
{
    public class SalaryPaymentService
    {
        DBService<SalaryPayment> salaryPayment = new DBService<SalaryPayment>();
        DBService<LedgerPosting> service = new DBService<LedgerPosting>();

        public SalaryPayment Save(SalaryPayment SP)
        {
            var max = service.LastRow().OrderByDescending(a => a.Id).FirstOrDefault();
            SP.VoucherNo = max.VoucherNo;
            SP.LedgerId = max.LedgerId;

            var Max = salaryPayment.LastRow().OrderByDescending(a => a.Id).FirstOrDefault();
            if (Max == null)
            {
                SP.Id = 1;
            }
            else
            {
                SP.Id = max.Id + 1;

            }
            var result = salaryPayment.Save(SP);
            return result;
        }
    }
}