using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Controllers
{
    public class Task4Controller : Controller
    {
        // GET: Task4
        [HandleError(ExceptionType = typeof(DivideByZeroException), View= "DivideByZero")]
        
        public ActionResult Index()
        {
            throw new DivideByZeroException();
        }
        
    }
}