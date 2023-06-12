using Practical_13_Task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Practical_13_Task2.Controllers
{
    public class DesignationController : Controller
    {
       private EmployeeDBContext context = new EmployeeDBContext();
        public ActionResult Index()
        {
            return View(context.Designations.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Designation designation)
        {
            if(ModelState.IsValid)
            {
                context.Designations.Add(designation);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Designation designaton  = context.Designations.SingleOrDefault(d => d.DesignationId == id);
            if(designaton != null) { 
                return View(designaton);
            }
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Designation designation)
        {
            if(ModelState.IsValid)
            {
                Designation updateDesignation = context.Designations.Single(d => d.DesignationId == designation.DesignationId);
                UpdateModel(updateDesignation);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Designation designation = context.Designations.SingleOrDefault(d => d.DesignationId == id);
            if(designation != null)
            {
                return View(designation);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Designation designation = context.Designations.SingleOrDefault(d => d.DesignationId == id);
            if(designation != null)
            {
                context.Designations.Remove(designation);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}