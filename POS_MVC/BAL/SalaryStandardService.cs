using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using RexERP_MVC.Models;
using RexERP_MVC.Util;

namespace Service.Service
{
    public class SalaryStandardService : ISalaryStandardService
    {
        private ISalaryStandardRepository _repository;
        private ISalaryStandardValidator _validator;
        public SalaryStandardService(ISalaryStandardRepository _salaryStandardRepository, ISalaryStandardValidator _salaryStandardValidator)
        {
            _repository = _salaryStandardRepository;
            _validator = _salaryStandardValidator;
        }

        public ISalaryStandardValidator GetValidator()
        {
            return _validator;
        }

        public IQueryable<SalaryStandard> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public IList<SalaryStandard> GetAll()
        {
            return _repository.GetAll();
        }

        public SalaryStandard GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public SalaryStandard CreateObject(SalaryStandard salaryStandard, ITitleInfoService _titleInfoService, 
                                    ISalaryStandardDetailService _salaryStandardDetailService, ISalaryItemService _salaryItemService)
        {
           // salaryStandard.Errors = new Dictionary<String, String>();
            if(_validator.ValidCreateObject(salaryStandard, _titleInfoService))
            {
                _repository.CreateObject(salaryStandard);
                foreach (var x in Enum.GetNames(typeof(Constant.LegacySalaryItem)))
                {
                    SalaryStandardDetail ssd = new SalaryStandardDetail
                    {
                        SalaryStandardId = salaryStandard.Id,
                        SalaryItemId = _salaryItemService.GetObjectByCode(x).Id,
                    };
                    _salaryStandardDetailService.CreateObject(ssd, this, _salaryItemService);
                }
            }
            return salaryStandard;
        }

        public SalaryStandard UpdateObject(SalaryStandard salaryStandard, ITitleInfoService _titleInfoService)
        {
            return (salaryStandard = _validator.ValidUpdateObject(salaryStandard, _titleInfoService) ? _repository.UpdateObject(salaryStandard) : salaryStandard);
        }

        public SalaryStandard SoftDeleteObject(SalaryStandard salaryStandard)
        {
            return (salaryStandard = _validator.ValidDeleteObject(salaryStandard) ?
                    _repository.SoftDeleteObject(salaryStandard) : salaryStandard);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }

        
    }
}