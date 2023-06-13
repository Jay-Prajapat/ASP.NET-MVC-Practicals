using Practical_15_Task_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Practical_15_Task_2.Controllers
{
    public class AccountsController : Controller
    {
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            using (UsersDBEmployee context = new UsersDBEmployee())
            {
                bool isValidUser = context.Users.Any(user => user.UserName == model.UserName && user.UserPassword == model.UserPassword);
                if (isValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index","Employee");
                }
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User model)
        {
            using(UsersDBEmployee context = new UsersDBEmployee())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}