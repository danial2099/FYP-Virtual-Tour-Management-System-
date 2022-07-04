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
    public class MediaController : Controller
    {
        // GET: Media
        public ActionResult Index()
        {
            using (mediaModels modelMedia= new mediaModels())
            {
                
                return View(modelMedia.Media.ToList());
            }
            
        }

        // GET: Media/Details/5
        //public ActionResult Details(int id)
        //{
        //    using (mediaModels modelMedia2= new mediaModels())
        //    {
        //        return View(modelMedia2.Media.Where(x=>x.id==id).FirstOrDefault());
        //    }
            
        //}

        // GET: Media/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        [HttpPost]
        public ActionResult Create(Medium medium)
        {
            try
            {
                using (mediaModels modelMedia1 = new mediaModels())
                {
                    modelMedia1.Media.Add(medium);
                    modelMedia1.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Media/Edit/5
        public ActionResult Edit(int id)
        {
            using (mediaModels modelMedia2 = new mediaModels())
            {
                return View(modelMedia2.Media.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Media/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Medium medium)
        {
            try
            {
                using (mediaModels modelMedia3 = new mediaModels())
                {
                    modelMedia3.Entry(medium).State = EntityState.Modified;
                    modelMedia3.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Media/Delete/5
        public ActionResult Delete(int id)
        {
            using (mediaModels modelMedia4 = new mediaModels())
            {
                return View(modelMedia4.Media.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Media/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (mediaModels mediaModel5 = new mediaModels())
                {
                    Medium medium = mediaModel5.Media.Where(x => x.id == id).FirstOrDefault();
                    mediaModel5.Media.Remove(medium);
                    mediaModel5.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
