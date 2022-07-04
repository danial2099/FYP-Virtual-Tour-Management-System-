using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult AdminRegis(int Id=0)
        {
            Admin adminModel = new Admin();
            return View(adminModel);
        }
        [HttpPost]
        public ActionResult AdminRegis(Admin adminModel)
        {
            using (PSM2DBEntities6 dbModel2 = new PSM2DBEntities6())
            {
                dbModel2.Admins.Add(adminModel);
                dbModel2.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AdminRegis", new Admin());
        }
    }
}