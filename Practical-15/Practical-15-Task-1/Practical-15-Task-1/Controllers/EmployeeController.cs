using Practical_15_Task_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_15_Task_1.Controllers
{
    [Authorize(Users = "SF-CPU-336\\install")]
    public class EmployeeController : Controller
    {
        private static List<Employee> _employee = new List<Employee>()
        {
            new Employee { Id = 1,FirstName = "Jay", LastName = "Prajapati", Department = ".NET"},
            new Employee { Id = 2, FirstName = "Gaurav", LastName = "Mori", Department = ".NET"},
            new Employee { Id = 3, FirstName = "Suman", LastName = "Jha", Department = ".NET"},
            new Employee { Id = 4, FirstName = "Jayesh", LastName = "Bellani", Department = "Java" }
        };
        // GET: Employee
       
        public ActionResult Index()
        {
            return View(_employee);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee employee = _employee.SingleOrDefault(x => x.Id == id);
            if(employee != null) {
                return View(employee);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = _employee.SingleOrDefault(e => e.Id == id); 
            if(employee != null)
            {
                return View(employee);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            Employee updateEmployee = _employee.SingleOrDefault(e => e.Id == employee.Id);
            if(updateEmployee != null)
            {
                updateEmployee.FirstName = employee.FirstName;
                updateEmployee.LastName = employee.LastName;
                updateEmployee.Department = employee.Department;
                return RedirectToAction("Index");   
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee employee = _employee.SingleOrDefault(e => e.Id == id);
            if(employee != null)
            {
                _employee.Remove(employee);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employee.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}