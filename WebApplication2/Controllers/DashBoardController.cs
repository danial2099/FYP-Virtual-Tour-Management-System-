using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace WebApplication2.Models
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            using (mediaModels modelMedia = new mediaModels())
            {
                return View(modelMedia.Media.ToList());
            }
        }


    }
}