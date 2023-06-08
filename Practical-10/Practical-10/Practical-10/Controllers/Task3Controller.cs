using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10.Controllers
{
    public class Task3Controller : Controller
    {
        // GET: Task3
        [OutputCache(Duration =300)]
        public DateTime Index()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate;
        }
    }
}