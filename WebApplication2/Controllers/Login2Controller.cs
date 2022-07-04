using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Login2Controller : Controller
    {
        // GET: Login2
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(WebApplication2.Models.Admin adminModel)
        {
            using (PSM2DBEntities6 db = new PSM2DBEntities6())
            {
                var adminDetails = db.Admins.Where(x => x.AdminNo == adminModel.AdminNo && x.Password == adminModel.Password).FirstOrDefault();
                if (adminDetails == null)
                {
                    adminModel.LoginErrorMessage = "Wrong Admin No no or password ";
                    return View("Index", adminModel);
                }
                else
                {
                    Session["AdminNo"] = adminDetails.AdminNo;
                    Session["Name"] = adminDetails.Name;
                    return RedirectToAction("Index", "AdminDashboard");
                }

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login2");
        }
    }
}