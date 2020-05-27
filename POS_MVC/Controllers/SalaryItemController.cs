using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Service.Service;
using Core.Interface.Service;
using Data.Repository;
using Validation.Validation;
using System.Data.Entity;
using RexERP_MVC.Models;
using RexERP_MVC.Util;

namespace RexERP_MVC.Controllers
{

    public class SalaryItemController : Controller
    {
        private readonly static log4net.ILog LOG = log4net.LogManager.GetLogger("SalaryItemController");

        public SalaryItemController()
        {
        }

        public ActionResult Index()
        {
         
            return View(this);
        }

        //public dynamic GetList(string _search, long nd, int rows, int? page, string sidx, string sord, string filters = "", int ParentId = 0)
        //{
        //    // Construct where statement
        //    string strWhere = GeneralFunction.ConstructWhere(filters);
        //    string filter = null;
        //    GeneralFunction.ConstructWhereInLinq(strWhere, out filter);
        //    if (filter == "") filter = "true";

        //    // Get Data
        //    var q = _salaryItemService.GetQueryable(); //.Include("Division").Where(x => x.DivisionId == ParentId);

        //    var query = (from model in q
        //                 select new
        //                 {
        //                     model.Id,
        //                     model.Code,
        //                     model.Name,
        //                     model.Description,
        //                     model.IsLegacy,
        //                     model.SalaryItemType,
        //                     model.SalaryItemStatus,
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
        //                     model.Id,
        //                     model.Code,
        //                     model.Name,
        //                     model.Description,
        //                     model.IsLegacy,
        //                     model.SalaryItemType,
        //                     model.SalaryItemStatus,
        //                     model.CreatedAt,
        //                     model.UpdatedAt,
        //              }
        //            }).ToArray()
        //    }, JsonRequestBehavior.AllowGet);
        //}

        public dynamic GetInfo(int Id)
        {
            PayHead model = new PayHead();
            try
            {
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
              
             //   model.Errors
            }, JsonRequestBehavior.AllowGet);
        }

        public dynamic GetDefaultInfo()
        {
            PayHead model = new PayHead();
            try
            {
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
                model.Id
            //    model.Errors
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public dynamic Insert(PayHead model)
        {
            try
            {
                //if (!AuthenticationModel.IsAllowed("Create", Core.Constants.Constant.MenuName.SalaryItems, Core.Constants.Constant.MenuGroupName.Setting))
                //{
                //    Dictionary<string, string> Errors = new Dictionary<string, string>();
                //    Errors.Add("Generic", "You are Not Allowed to Add record");

                //    return Json(new
                //    {
                //        Errors
                //    }, JsonRequestBehavior.AllowGet);
                //}

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

            return Json(new
            {
              //  model.Errors
            });
        }

        [HttpPost]
        public dynamic Update(PayHead model)
        {
            try
            {
                //if (!AuthenticationModel.IsAllowed("Edit", Core.Constants.Constant.MenuName.SalaryItems, Core.Constants.Constant.MenuGroupName.Setting))
                //{
                //    Dictionary<string, string> Errors = new Dictionary<string, string>();
                //    Errors.Add("Generic", "You are Not Allowed to Edit record");

                //    return Json(new
                //    {
                //        Errors
                //    }, JsonRequestBehavior.AllowGet);
                //}


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

            return Json(new
            {
               // model.Errors
            });
        }

        [HttpPost]
        public dynamic Delete(PayHead model)
        {
            try
            {
                //if (!AuthenticationModel.IsAllowed("Delete", Core.Constants.Constant.MenuName.SalaryItems, Core.Constants.Constant.MenuGroupName.Setting))
                //{
                //    Dictionary<string, string> Errors = new Dictionary<string, string>();
                //    Errors.Add("Generic", "You are Not Allowed to Delete Record");

                //    return Json(new
                //    {
                //        Errors
                //    }, JsonRequestBehavior.AllowGet);
                //}

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

            return Json(new
            {
              //  model.Errors
            });
        }
    }
}
