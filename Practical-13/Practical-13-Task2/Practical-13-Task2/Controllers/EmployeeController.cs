using Practical_13_Task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Practical_13_Task2.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDBContext context = new EmployeeDBContext();
        public ActionResult Index()
        {
            return View(context.Employees.Include(a => a.Designation).ToList());
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(context.Designations.ToList(), "DesignationId", "DesignationName");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            ViewBag.DesignationId = new SelectList(context.Designations.ToList(), "DesignationId", "DesignationName");


            if (ModelState.IsValid)
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
             ViewBag.DesignationId = new SelectList(context.Designations.ToList(), "DesignationId", "DesignationName");

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
                Employee emp = context.Employees.SingleOrDefault(e => e.Id == employee.Id);
                UpdateModel(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee employee = context.Employees.SingleOrDefault(e => e.Id ==id);
            if(employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee employee = context.Employees.Include("Designation").SingleOrDefault(e => e.Id == id);
            if(employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index");
        }

    
        public ActionResult Count()
        {
           var result=  context.Employees.Include(d => d.Designation).GroupBy(e => e.Designation.DesignationName)
                        .Select(x => new CountModel() { Name = x.Key, Count = x.Count() }).ToList() ;
            return View(result);
        }
        
    }
}