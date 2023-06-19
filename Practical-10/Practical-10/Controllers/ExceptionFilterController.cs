using System;
using System.Web.Mvc;

namespace Practical_10.Controllers
{
    public class ExceptionFilterController : Controller
    {
      
        [HandleError(ExceptionType = typeof(DivideByZeroException), View= "DivideByZero")]
        
        public ActionResult Index()
        {
            int num1 = 10;
            int num2 = 0;
            int result = num1 / num2;
            return View();
        }
        
    }
}