using Practical_11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace Practical_11.Controllers
{
    public class PersonController : Controller
    {
        public static List<Person> _persons = new List<Person>()
        {
            new Person { Id = 1,Name = "Jay",DateOfBirth = new DateTime(2002,01,15),Address="Vyara"},
            new Person { Id = 2,Name="Gaurav",DateOfBirth=new DateTime(2002,03,12),Address="Bhavnagar"},
            new Person { Id = 3,Name="Suman",DateOfBirth=new DateTime(2000,07,07),Address="Nepal"}
        };
        // GET: Person
        public ActionResult Index()
        {
            return View(_persons);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                
                _persons.Add(person);
                return RedirectToAction("Index");
            }
           
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_persons.Single(person => person.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                Person newPerson = _persons.Single(p => p.Id == person.Id);
                newPerson.Name = person.Name;   
                newPerson.Address = person.Address;
                newPerson.DateOfBirth = person.DateOfBirth;
                
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Person person = _persons.Single(p => p.Id==id);
            if (person != null)
            {
                _persons.Remove(person);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Person person = _persons.Single(p => p.Id == id);
            if (person != null)
            {
                return View(person);
            }
            return View();
        }

        
    }
}