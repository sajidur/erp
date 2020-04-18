﻿using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;
using RexERP_MVC.Util;
namespace Service.Service
{
    public class SalaryItemService : ISalaryItemService
    {
        private ISalaryItemRepository _repository;
        private ISalaryItemValidator _validator;
        public SalaryItemService(ISalaryItemRepository _salaryItemRepository, ISalaryItemValidator _salaryItemValidator)
        {
            _repository = _salaryItemRepository;
            _validator = _salaryItemValidator;
        }

        public ISalaryItemValidator GetValidator()
        {
            return _validator;
        }

        public IQueryable<SalaryItem> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public IList<SalaryItem> GetAll()
        {
            return _repository.GetAll();
        }

        public SalaryItem GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public SalaryItem GetObjectByCode(string Code)
        {
            return _repository.FindAll(x => x.Code == Code && !x.IsDeleted).FirstOrDefault();
        }

        public SalaryItem GetObjectByCode(Constant.LegacyAttendanceItem Code)
        {
            string scode = Enum.GetName(typeof(Constant.LegacyAttendanceItem), Code);
            return _repository.FindAll(x => x.Code == scode && !x.IsDeleted).FirstOrDefault();
        }

        public SalaryItem GetObjectByCode(Constant.LegacySalaryItem Code)
        {
            string scode = Enum.GetName(typeof(Constant.LegacySalaryItem), Code);
            return _repository.FindAll(x => x.Code == scode && !x.IsDeleted).FirstOrDefault();
        }

        public SalaryItem GetObjectByCode(Constant.LegacyMonthlyItem Code)
        {
            string scode = Enum.GetName(typeof(Constant.LegacyMonthlyItem), Code);
            return _repository.FindAll(x => x.Code == scode && !x.IsDeleted).FirstOrDefault();
        }

        public SalaryItem FindOrCreateObject(string Code, string Name, int SalarySign, int SalaryItemType, int SalaryStatus, bool IsMainSalary, bool IsDetailSalary, bool IsLegacy)
        {
            SalaryItem salaryItem = GetObjectByCode(Code);
            if (salaryItem != null)
            {
                return salaryItem;
            }
            salaryItem = new SalaryItem
            {
                Code = Code,
                Name = Name,
                SalarySign = SalarySign,
                SalaryItemType = SalaryItemType,
                SalaryItemStatus = SalaryStatus,
                IsMainSalary = IsMainSalary,
                IsDetailSalary = IsDetailSalary,
                IsLegacy = IsLegacy,
            };
            return this.CreateObject(salaryItem);
        }

        public SalaryItem CreateObject(string Code, string Name, int SalarySign, int SalaryItemType, int SalaryStatus, bool IsMainSalary, bool IsDetailSalary, bool IsLegacy)
        {
            SalaryItem salaryItem = new SalaryItem
            {
                Code = Code,
                Name = Name,
                SalarySign = SalarySign,
                SalaryItemType = SalaryItemType,
                SalaryItemStatus = SalaryStatus,
                IsMainSalary = IsMainSalary,
                IsDetailSalary = IsDetailSalary,
                IsLegacy = IsLegacy,
            };
            return this.CreateObject(salaryItem);
        }

        public SalaryItem CreateObject(SalaryItem salaryItem)
        {
          //  salaryItem.Errors = new Dictionary<String, String>();
            return (_validator.ValidCreateObject(salaryItem, this) ? _repository.CreateObject(salaryItem) : salaryItem);
        }

        public SalaryItem UpdateObject(SalaryItem salaryItem)
        {
            return (salaryItem = _validator.ValidUpdateObject(salaryItem, this) ? _repository.UpdateObject(salaryItem) : salaryItem);
        }

        public SalaryItem SoftDeleteObject(SalaryItem salaryItem)
        {
            return (salaryItem = _validator.ValidDeleteObject(salaryItem) ?
                    _repository.SoftDeleteObject(salaryItem) : salaryItem);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }

        public bool IsCodeDuplicated(SalaryItem salaryItem)
        {
            IQueryable<SalaryItem> salaryItems = _repository.FindAll(x => x.Code == salaryItem.Code && !x.IsDeleted && x.Id != salaryItem.Id);
            return (salaryItems.Count() > 0 ? true : false);
        }

        //public decimal CalcSalaryItem(int salaryItemId, int employeeId, DateTime date, IFormulaService _formulaService,
        //                    ISalaryEmployeeDetailService _salaryEmployeeDetailService, IEmployeeAttendanceDetailService _employeeAttendanceDetailService)
        //{
        //    decimal val = 0;
        //    SalaryItem salaryItem = GetObjectById(salaryItemId);
        //    if (salaryItem != null)
        //    {
        //        if (salaryItem.FormulaId.GetValueOrDefault() > 0)
        //        {
        //            val = _formulaService.CalcFormula(salaryItem.FormulaId.GetValueOrDefault(), employeeId, date, this, _salaryEmployeeDetailService, _employeeAttendanceDetailService);
        //        }
        //        else
        //        {
        //            if (Enum.IsDefined(typeof(Constant.LegacySalaryItem), salaryItem.Code))
        //            {
        //                val = _salaryEmployeeDetailService.GetObjectByEmployeeIdAndSalaryItemId(employeeId, salaryItem.Id, date).Amount;
        //            }
        //            else if (Enum.IsDefined(typeof(Constant.LegacyAttendanceItem), salaryItem.Code))
        //            {
        //                val = _employeeAttendanceDetailService.GetObjectByEmployeeIdAndSalaryItemId(employeeId, salaryItem.Id, date).Amount;
        //            }
        //            else if (Enum.IsDefined(typeof(Constant.LegacyMonthlyItem), salaryItem.Code))
        //            {
        //                val = _employeeAttendanceDetailService.GetObjectByEmployeeIdAndSalaryItemId(employeeId, salaryItem.Id, date).Amount;
        //            }
        //            else
        //            {
        //                val = salaryItem.DefaultValue;
        //            }
        //        }
        //    }
        //    return val;
        //}

        /// <summary>
        /// Menghitung nilai Salary item
        /// </summary>
        /// <param name="salaryItem">Object salary item</param>
        /// <param name="salaryItemsValue">Pair antara salaryitem code dengan nilainya</param>
        /// <param name="_formulaService">Service formula</param>
        /// <returns></returns>
        public decimal CalcSalaryItem(SalaryItem salaryItem, IDictionary<string, decimal> salaryItemsValue, IFormulaService _formulaService)
        {
            decimal val = 0;
            //SalaryItem salaryItem = GetObjectById(salaryItemId);
            if (salaryItem != null)
            {
                try
                {
                    val = salaryItemsValue[salaryItem.Code];
                }
                catch
                {
                    if (salaryItem != null)
                    {
                        val = salaryItem.DefaultValue; // CurrentValue
                    }
                }
                //if (salaryItem.FormulaId.GetValueOrDefault() > 0)
                //{
                //    var salaryItems = GetQueryable();
                //    val = _formulaService.CalcFormula(salaryItem.Formula, salaryItemsValue, salaryItems);
                //}
                //else
                //{
                //    if (Enum.IsDefined(typeof(Constant.LegacySalaryItem), salaryItem.Code))
                //    {
                //        val = salaryItemsValue[salaryItem.Code]; // _salaryEmployeeDetailService.GetObjectByEmployeeIdAndSalaryItemId(employeeId, salaryItem.Id, date).Amount;
                //    }
                //    else if (Enum.IsDefined(typeof(Constant.LegacyAttendanceItem), salaryItem.Code))
                //    {
                //        val = salaryItemsValue[salaryItem.Code]; // _employeeAttendanceDetailService.GetObjectByEmployeeIdAndSalaryItemId(employeeId, salaryItem.Id, date).Amount;
                //    }
                //    else if (Enum.IsDefined(typeof(Constant.LegacyMonthlyItem), salaryItem.Code))
                //    {
                //        val = salaryItemsValue[salaryItem.Code]; // _employeeAttendanceDetailService.GetObjectByEmployeeIdAndSalaryItemId(employeeId, salaryItem.Id, date).Amount;
                //    }
                //    else
                //    {
                //        val = salaryItem.DefaultValue;
                //    }
                //}
            }
            return val;
        }

    }
}