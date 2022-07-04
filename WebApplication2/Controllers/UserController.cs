using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult AddOrEdit(int Id=0)
        {
            User userModel = new User();
            return View(userModel);
        }
    
        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
           using (PSM2DBEntities4 dbModel = new PSM2DBEntities4())
            {
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successfully";
            return View("AddOrEdit", new User());
        }
        
    }

}   