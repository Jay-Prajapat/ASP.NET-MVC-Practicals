using Practical_14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Microsoft.Ajax.Utilities;

namespace Practical_14.Controllers
{
    public class EmployeeController : Controller
    {
        
        private EmployeeDBContext context = new EmployeeDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployee()
        {
            return Json(context.Employees.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee) 
        {
            if(ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            Employee employee = context.Employees.SingleOrDefault(e => e.Id == id);
            if(employee != null) 
            {
                return View(employee);    
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if(ModelState.IsValid)
            {
                Employee updateEmployee = context.Employees.SingleOrDefault(e => e.Id == employee.Id);
                UpdateModel(updateEmployee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee employee = context.Employees.SingleOrDefault(e => e.Id == id);
            if(employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Details(int id) 
        {
            Employee employee = context.Employees.SingleOrDefault(e => e.Id ==id);
            if(employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index");

        }

    }
}