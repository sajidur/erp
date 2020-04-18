﻿using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RexERP_MVC.Models;

namespace Service.Service
{
    public class SalaryStandardDetailService : ISalaryStandardDetailService
    {
        private ISalaryStandardDetailRepository _repository;
        private ISalaryStandardDetailValidator _validator;
        public SalaryStandardDetailService(ISalaryStandardDetailRepository _salaryStandardDetailRepository, ISalaryStandardDetailValidator _salaryStandardDetailValidator)
        {
            _repository = _salaryStandardDetailRepository;
            _validator = _salaryStandardDetailValidator;
        }

        public ISalaryStandardDetailValidator GetValidator()
        {
            return _validator;
        }

        public IQueryable<SalaryStandardDetail> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public IList<SalaryStandardDetail> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<SalaryStandardDetail> GetObjectsByTitleInfoId(int TitleInfoId)
        {
            return _repository.GetObjectsByTitleInfoId(TitleInfoId);
        }

        public SalaryStandardDetail GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public SalaryStandardDetail GetObjectBySalaryItemId(int SalaryItemId, int SalaryStandardId)
        {
            return _repository.FindAll(x => x.SalaryItemId == SalaryItemId && x.SalaryStandardId == SalaryStandardId && !x.IsDeleted).Include("SalaryStandard").Include("SalaryItem").FirstOrDefault();
        }

        public SalaryStandardDetail CreateObject(SalaryStandardDetail salaryStandardDetail, ISalaryStandardService _salaryStandardService, ISalaryItemService _salaryItemService)
        {
           // salaryStandardDetail.Errors = new Dictionary<String, String>();
            return (_validator.ValidCreateObject(salaryStandardDetail, _salaryStandardService, _salaryItemService) ? _repository.CreateObject(salaryStandardDetail) : salaryStandardDetail);
        }

        public SalaryStandardDetail UpdateObject(SalaryStandardDetail salaryStandardDetail, ISalaryStandardService _salaryStandardService, ISalaryItemService _salaryItemService)
        {
            return (salaryStandardDetail = _validator.ValidUpdateObject(salaryStandardDetail, _salaryStandardService, _salaryItemService) ? _repository.UpdateObject(salaryStandardDetail) : salaryStandardDetail);
        }

        public SalaryStandardDetail SoftDeleteObject(SalaryStandardDetail salaryStandardDetail)
        {
            return (salaryStandardDetail = _validator.ValidDeleteObject(salaryStandardDetail) ?
                    _repository.SoftDeleteObject(salaryStandardDetail) : salaryStandardDetail);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }

        
    }
}