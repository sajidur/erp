﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Core.Interface.Service;
using Service.Service;
using Data.Repository;
using Validation.Validation;
using RexERP_MVC.Models;
using RexERP_MVC.Util;

namespace WebView.Controllers
{
    public class CompanyInfoController : Controller
    {
        private readonly static log4net.ILog LOG = log4net.LogManager.GetLogger("CompanyInfoController");
        public ICompanyInfoService _companyInfoService;
        public IBranchOfficeService _branchOfficeService;

        public CompanyInfoController()
        {
            _companyInfoService = new CompanyInfoService(new CompanyInfoRepository(), new CompanyInfoValidator());
            _branchOfficeService = new BranchOfficeService(new BranchOfficeRepository(), new BranchOfficeValidator());
        }

        public ActionResult Index()
        {
           // return Content(Constant.ErrorPage.PageViewNotAllowed);
            return View();
        }

        //public dynamic GetList(string _search, long nd, int rows, int? page, string sidx, string sord, string filters = "")
        //{
        //    // Construct where statement
        //    string strWhere = GeneralFunction.ConstructWhere(filters);
        //    string filter = null;
        //    GeneralFunction.ConstructWhereInLinq(strWhere, out filter);
        //    if (filter == "") filter = "true";

        //    // Get Data
        //    var q = _companyInfoService.GetQueryable();

        //    var query = (from model in q
        //                 select new
        //                 {
        //                     model.Id,
        //                     model.Name,
        //                     model.Address,
        //                     model.City,
        //                     model.PostalCode,
        //                     model.PhoneNumber,
        //                     model.FaxNumber,
        //                     model.Email,
        //                     model.Website,
        //                     model.NPWP,
        //                     model.NPWPDate,
        //                     model.CreatedAt,
        //                     model.UpdatedAt,
        //                 }).Where(filter).OrderBy(sidx + " " + sord); //.ToList();

        //    var list = query.AsEnumerable();

        //    var pageIndex = Convert.ToInt32(page) - 1;
        //    var pageSize = rows;
        //    var totalRecords = query.Count();
        //    var totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
        //    // default last page
        //    if (totalPages > 0)
        //    {
        //        if (!page.HasValue)
        //        {
        //            pageIndex = totalPages - 1;
        //            page = totalPages;
        //        }
        //    }

        //    list = list.Skip(pageIndex * pageSize).Take(pageSize);

        //    return Json(new
        //    {
        //        total = totalPages,
        //        page = page,
        //        records = totalRecords,
        //        rows = (
        //            from model in list
        //            select new
        //            {
        //                id = model.Id,
        //                cell = new object[] {
        //                    model.Id,
        //                    model.Name,
        //                    model.Address,
        //                    model.City,
        //                    model.PostalCode,
        //                    model.PhoneNumber,
        //                    model.FaxNumber,
        //                    model.Email,
        //                    model.Website,
        //                    model.NPWP,
        //                    model.NPWPDate,
        //                    model.CreatedAt,
        //                    model.UpdatedAt,
        //              }
        //            }).ToArray()
        //    }, JsonRequestBehavior.AllowGet);
        //}


        public dynamic GetInfo(int Id)
        {
            CompanyInfo model = new CompanyInfo();
            try
            {
                model = _companyInfoService.GetObjectById(Id);
            }
            catch (Exception ex)
            {
                LOG.Error("GetInfo", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                model.Id,
                model.Name,
                model.Address,
                model.City,
                model.PostalCode,
                model.PhoneNumber,
                model.FaxNumber,
                model.Email,
                model.Website,
                model.NPWP,
                model.NPWPDate
            }, JsonRequestBehavior.AllowGet);
        }

        public dynamic GetDefaultInfo()
        {
            CompanyInfo model = new CompanyInfo();
            try
            {
                model = _companyInfoService.GetQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                LOG.Error("GetInfo", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                model.Id,
                model.Name,
                model.Address,
                model.City,
                model.PostalCode,
                model.PhoneNumber,
                model.FaxNumber,
                model.Email,
                model.Website,
                model.NPWP,
                model.NPWPDate
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public dynamic Insert(CompanyInfo model)
        {
            try
            {
                model = _companyInfoService.CreateObject(model);
                return Json(model, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                LOG.Error("Insert Failed", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public dynamic Update(CompanyInfo model)
        {
            try
            {
                var data = _companyInfoService.GetObjectById(model.Id);
                data.Name = model.Name;
                data.Address = model.Address;
                data.City = model.City;
                data.PostalCode = model.PostalCode;
                data.PhoneNumber = model.PhoneNumber;
                data.FaxNumber = model.FaxNumber;
                data.Email = model.Email;
                data.Website = model.Website;
                data.NPWP = model.NPWP;
                data.NPWPDate = model.NPWPDate;
                model = _companyInfoService.UpdateObject(data);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LOG.Error("Update Failed", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public dynamic Delete(CompanyInfo model)
        {
            try
            {
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "You are Not Allowed to Delete Record");

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
                var data = _companyInfoService.GetObjectById(model.Id);
                model = _companyInfoService.SoftDeleteObject(data, _branchOfficeService);
            }

            catch (Exception ex)
            {
                LOG.Error("Delete Failed", ex);
                Dictionary<string, string> Errors = new Dictionary<string, string>();
                Errors.Add("Generic", "Error " + ex);

                return Json(new
                {
                    Errors
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
