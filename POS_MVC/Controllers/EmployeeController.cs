﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using RexERP_MVC.BAL;
using RexERP_MVC.Models;
using RexERP_MVC.RequestModel;
using RexERP_MVC.Util;
using RexERP_MVC.ViewModel;

namespace RexERP_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService db = new EmployeeService();
        private AccountLedgerService Accounts = new AccountLedgerService();
        private LedgerPostingService lps = new LedgerPostingService();
        private SalaryPaymentService salaryPaymentService = new SalaryPaymentService();


        // GET: Employee
        public ActionResult AddEmployee()
        {

            ViewBag.Title = "Employee";
            return View();
        }

        

        [HttpPost]
        public ActionResult Create(EmployeeRequest request)
        {
            if (ModelState.IsValid)
            {
                //var file = request.imageView.ImageFile;
                //if (file != null)
                //{
                //    //file.SaveAs(Server.MapPath("/UploadEmployeeImage" + file.FileName));
                //    BinaryReader reader = new BinaryReader(file.InputStream);
                //    ImageByte = reader.ReadBytes(file.ContentLength);
                //    employee.Photo = ImageByte;
                //}
                AccountLedger ledger = new AccountLedger();
                ledger.AccountGroupId = 1;
                ledger.Address = request.Address;
                ledger.BankAccountNumber = "";
                ledger.BillByBill = true;
                ledger.BranchCode = "";
                ledger.BranchName = "";
                ledger.CreditLimit = 0.0m;
                ledger.CreditPeriod = 1;
                ledger.CrOrDr = "Dr";
                ledger.Email = request.Email;
                ledger.IsDefault = false;
                ledger.LedgerName = request.Code + "-" + request.FirstName;
                ledger.Mobile = request.Phone;
                ledger.OpeningBalance = 0.0m;
                var saved = Accounts.Save(ledger);
                var employee = new Employee()
                {
                    CreationDate = DateTime.Now,
                    Creator = CurrentSession.GetCurrentSession().UserName,
                    IsActive = true,
                    Code = request.Code,
                    Address = request.Address,
                    City = request.City,
                    Email = request.Email,
                    FatherName = request.FatherName,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MotherName = request.MotherName,
                    Phone = request.Phone,
                    Remarks = request.Remarks,
                    Salary = request.Salary,
                    ZipCode = request.ZipCode,
                    LedgerId = saved.Id
                };
                var res=db.Save(employee);
                return Json(new {Id=res.Id }, JsonRequestBehavior.AllowGet);
            }
            return Json("Failed", JsonRequestBehavior.AllowGet);
        }
        private byte[] ImageByte = null;
        public void ImageUpload(ImageViewModel model)
        {
            var file = model.ImageFile;
            if (file != null)
            {
                //file.SaveAs(Server.MapPath("/UploadEmployeeImage" + file.FileName));
                BinaryReader reader = new BinaryReader(file.InputStream);
                ImageByte = reader.ReadBytes(file.ContentLength);
                ImageViewModel.bufferByte = ImageByte;
                var employee = db.GetById(model.EmpId);
                employee.Photo = ImageByte;
                db.Update(employee, model.EmpId);
            }
        }


        public ActionResult GetAll()
        {
            List<Employee> employees = db.GetAll();
            if (employees == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<Employee>, List<EmployeeResponse>>(employees);
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetAllByDesignation(int designationId)
        {
            List<Employee> employees = db.GetAll();
            if (employees == null)
            {
                return HttpNotFound();
            }
            var result = AutoMapper.Mapper.Map<List<Employee>, List<EmployeeResponse>>(employees);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetAllByName(string Name)
        {
            List<Employee> employees = db.GetAll(Name);
            if (employees == null)
            {
                return HttpNotFound();
            }
           
            return Json(employees, JsonRequestBehavior.AllowGet);

        }

        public ActionResult EmpSalarySave(List<SalaryPayment> salaryPayment, List<LedgerPosting> ledgerPosting)
        {
            foreach (var item in ledgerPosting)
            {
                LedgerPosting ledgersave = new LedgerPosting();
                ledgersave.VoucherTypeId = 6;
                ledgersave.LedgerId = item.LedgerId;
                ledgersave.Debit = item.Credit;
                ledgersave.Credit = 0;
                ledgersave.ChequeNo = item.ChequeNo;
                ledgersave.ChequeDate = item.ChequeDate;
                lps.Save(ledgersave);
            }

            foreach (var i in salaryPayment)
            {
                SalaryPayment sp = new SalaryPayment();
                sp.EmployeeId = i.EmployeeId;
                sp.SalaryAmount = i.SalaryAmount;
                sp.Bonus = i.TotalAmount - i.SalaryAmount;
                sp.TotalAmount = i.TotalAmount;
                sp.Date = i.Date;
                sp.Month = i.Month;
                salaryPaymentService.Save(sp);
            }
            
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            //var result = AutoMapper.Mapper.Map<Employee, EmployeeResponse>(employee);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.GetById(model.Id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            model.IsActive = true;
            model.UpdateDate = DateTime.Now;
            model.UpdateBy = CurrentSession.GetCurrentSession().UserName;
            model.Photo = ImageViewModel.bufferByte;
            db.Update(model, model.Id);
            return Json("Updated", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            employee.IsActive = false;
            db.Update(employee, id ?? 0);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
    }
}