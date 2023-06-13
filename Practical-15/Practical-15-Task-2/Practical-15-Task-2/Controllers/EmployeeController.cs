using Practical_15_Task_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_15_Task_2.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        UsersDBEmployee context = new UsersDBEmployee();

        public ActionResult Index()
        {
            return View(context.Employees.ToList());
        }

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