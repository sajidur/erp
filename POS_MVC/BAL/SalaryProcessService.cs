using Core.Interface.Service;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Globalization;
using System.Data.SqlTypes;
using RexERP_MVC.Util;
using RexERP_MVC.Models;
using System.Data.Entity.Core.Objects;
//using WebView.ObjectCopier;

namespace Service.Service
{
    public class SalaryProcessService : ISalaryProcessService
    {
        //struct NameSign
        //{
        //    public string name;
        //    public int sign;
        //};

        public decimal GetSalaryItemValue(Enum SalaryItemCode, IDictionary<string, decimal> salaryItemsValue, Dictionary<string, int> salaryItemsSign)
        {
            string code = SalaryItemCode.ToString();
            return salaryItemsValue[code] * salaryItemsSign[code];
        }

    }
}