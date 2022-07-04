using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(WebApplication2.Models.User userModel)
        {
            using (PSM2DBEntities4 db1 = new PSM2DBEntities4())
            {
                return RedirectToAction("Index", "Home");
            }

        }
        //public ActionResult Login(WebApplication2.Models.Admin userModel)
        //{
        //    using (PSM2DBEntities6 db1 = new PSM2DBEntities6())
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //}

        [HttpPost]
        public ActionResult Autherize(WebApplication2.Models.User userModel)
        {
          using(PSM2DBEntities4 db = new PSM2DBEntities4())
            {
                var userDetails = db.Users.Where(x => x.MatricNo == userModel.MatricNo && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails==null)
                {
                    userModel.LoginErrorMessage = "Wrong matric no or password ";
                    return View("Index", userModel);
                }
                else
                {
                    Session["MatricNo"] = userDetails.MatricNo;
                    Session["Name"] = userDetails.Name;
                    return RedirectToAction("List", "Dashboard");
                }
            }
            
            return View();
        }
       
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        
    }

}