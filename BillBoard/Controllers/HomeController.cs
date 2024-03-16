using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BillBoard.Models;
using BillBoard.DB;

namespace BillBoard.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext ctx;
        AppDbContext uu;
        public HomeController()
        {
            ctx = new AppDbContext();
            uu = new AppDbContext();
        }
        // GET: Home
        public ActionResult Index()
        {

            return View();


        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            var model = ctx.CntForm.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(ContactForm msg)
        {
            ctx.CntForm.Add(msg);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LogIn()
        {
            var model = uu.cred.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(User xx)
        {
            // Check if user is part of the system
            using (var zz = new AppDbContext())
            {
                var user = zz.cred.FirstOrDefault(s => s.Email == xx.Email);

                if ( user.Password == xx.Password)
                {
                    // Username exists, and password matches
                    // Store user information in session or set authentication cookie
                    // Redirect to a secure area or dashboard
                    // Example of storing user information in session:
                    Session["UserAut"] = user.Email;
                    return RedirectToAction("Index"); // Redirect to the desired page after successful login
                }
                else
                {
                    // Username does not exist or password doesn't match
                    // Redirect to a login error page or view
                    return RedirectToAction("SignUp"); // Redirect to the login error page or view
                }
            }
        }


        public ActionResult SignUp()
        {
            var model = uu.cred.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User use)
        {
            uu.cred.Add(use);
            uu.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}