using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard
        public ActionResult Index()
        {
            return View();
        }

        //List for students
        public ActionResult IndexList()
        {
            using (PSM2DBEntities4 db2 = new PSM2DBEntities4())
            {
                return View(db2.Users.ToList());
            }
        }
        //CREATE
        public ActionResult CreateUser()
        {
            using (PSM2DBEntities4 db2 = new PSM2DBEntities4())
            {
                return View();
            }
        }
        [HttpPost]

        //CREATE (POST)
        public ActionResult CreateUser(User userModel)
        {
            try
            {
                using (PSM2DBEntities4 db3 = new PSM2DBEntities4())
                {
                    db3.Users.Add(userModel);
                    db3.SaveChanges();
                }
                return RedirectToAction("IndexList");
            }
            catch
            {
                return View();
            }
        }

         //DETAILS
         public ActionResult Details(int id)
        {
            using (PSM2DBEntities4 dbModel = new PSM2DBEntities4())
            {
                return View(dbModel.Users.Where(x=> x.Id == id).FirstOrDefault());
            }
            
        }
         
        //EDIT
        public ActionResult Edit(int id)
        {
            using (PSM2DBEntities4 dbModel = new PSM2DBEntities4())
            {
                return View(dbModel.Users.Where(x => x.Id == id).FirstOrDefault());
            }
        }
       

        //EDIT (POST)
        [HttpPost]
        public ActionResult Edit(int id, User userModel)
        {
            try
            {
                using (PSM2DBEntities4 db4 = new PSM2DBEntities4())
                {
                    db4.Entry(userModel).State = EntityState.Modified;
                    db4.SaveChanges();
                }
                return RedirectToAction("IndexList");
            }
            catch
            {
                return View();
            }
        }

        //POST : AdminDashboard
        
        
        public ActionResult Delete(int id)
        {
            using (PSM2DBEntities4 dbModel = new PSM2DBEntities4())
            {
                return View(dbModel.Users.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        //DELETE (POST)
        public ActionResult Delete(int id , FormCollection formCollection)
        {
            try
            {
                using (PSM2DBEntities4 dbModel1 = new PSM2DBEntities4())
                {
                    User user = dbModel1.Users.Where(x => x.Id == id).FirstOrDefault();
                    dbModel1.Users.Remove(user);
                    dbModel1.SaveChanges();

                }
                return RedirectToAction("IndexList");
            }
            catch
            {
                return View();
            }
        }

       
       
    }
}