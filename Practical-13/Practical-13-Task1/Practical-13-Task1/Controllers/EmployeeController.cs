using Practical_13_Task1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_13_Task1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private EmployeeDBContext context = new EmployeeDBContext();
        public ActionResult Index()
        {
            return View(context.Employees.ToList());
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            return View(context.Employees.Single(emp => emp.Id == id));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee employee = context.Employees.Single(emp => emp.Id == id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(context.Employees.Single(emp => emp.Id == id));
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            Employee updateEmployee = context.Employees.Single(e => e.Id == employee.Id);
            UpdateModel(updateEmployee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View (context.Employees.Single(e => e.Id == id));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}