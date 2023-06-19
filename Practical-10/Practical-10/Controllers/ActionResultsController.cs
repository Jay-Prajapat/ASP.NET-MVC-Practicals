﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Controllers
{
    public class ActionResultsController : Controller
    {
        // GET: ActionResults
        public ContentResult Index()
        {
            return Content("<h4>Hello, this is content result</h4>");
        }
        public ViewResult ViewResult()
        {
            ViewBag.Message = "Hello from View Result action result!!!";
            return View();
        }

        public FileResult FileResultAction()
        {
            ViewBag.Message = "Hello from File Content action result!!!";
            return File("~/Files/Text.txt", "text/plain");
        }

        public FileContentResult FileContentAction()
        {
            var myfile = "~/Text.txt";
            var path = Server.MapPath(myfile);
            var filecontent = System.IO.File.ReadAllBytes(path);

            return new FileContentResult(filecontent, "text/plain");
        }

        public EmptyResult EmptyResultAction()
        {
            return new EmptyResult();
        }

        public JsonResult JsonResultAction()
        {
            return Json(new { Name = "jay", Id = 101 }, JsonRequestBehavior.AllowGet);
        }

        public JavaScriptResult JavaScriptResultAction()
        {
            return JavaScript("alert('Hello from JavaScriptResultAction method');");
        }

        public PartialViewResult PartialViewResultAction()
        {
            return PartialView("_partialView");
        }
        public RedirectResult RedirectResultAction()
        {
            return Redirect("https://learn.microsoft.com/en-us/dotnet/csharp/");
        }
    }
}