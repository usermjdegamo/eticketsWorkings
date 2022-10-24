using ET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ET.Controllers
{
    public class ManagementController : Controller
    {
        Database1Entities db = new Database1Entities();

        // GET: Management
        [HttpGet]
        public ActionResult Actor()
        {
            var data = db.Actors.ToList();
            List<Actor> newdata = data;

            return View(newdata);
        }

        [HttpPost]
        public ActionResult Actor(Actor ba)
        {
            var data = db.Actors.ToList();
            List<Actor> newdata = data;

            if (ModelState.IsValid)
            {
                db.Actors.Add(ba);
                db.SaveChanges();
            }
            return View(newdata);
        }

        [HttpGet]
        public ActionResult Producer()
        {
            var data = db.Producers.ToList();
            List<Producer> newdata = data;

            return View(newdata);
        }

        [HttpPost]
        public ActionResult Producer(Producer ba)
        {
            var data = db.Producers.ToList();
            List<Producer> newdata = data;

            if (ModelState.IsValid)
            {
                db.Producers.Add(ba);
                db.SaveChanges();
            }
            return View(newdata);
        }

        [HttpGet]
        public ActionResult Cinema()
        {
            var data = db.Cinemas.ToList();
            List<Cinema> newdata = data;

            return View(newdata);
        }

        [HttpPost]
        public ActionResult Cinema(Cinema ba)
        {
            var data = db.Cinemas.ToList();
            List<Cinema> newdata = data;

            if (ModelState.IsValid)
            {
                db.Cinemas.Add(ba);
                db.SaveChanges();
            }
            return View(newdata);
        }

        [HttpGet]
        public ActionResult Movie()
        {
            var data = db.Movies.ToList();
            List<Movie> newdata = data;

            var list = db.Cinemas.ToList();
            var list2 = db.Producers.ToList();
            var list3 = db.Actors.ToList();

            //var db22 = db.Movies.Where(x => x.cinemaID == ).FirstOrDefault();

            ViewBag.cinemaName = new SelectList(list, "name", "name");
            ViewBag.producerName = new SelectList(list2, "fullName", "fullName");
            ViewBag.actorName = new SelectList(list3, "fullName", "fullName");

            return View(newdata);
        }

        [HttpPost]
        public ActionResult Movie(Movie ba, string cinemaName = null, string producerName = null, string actorName = null)
        {
            var data2 = db.Cinemas.Where(x => x.name == cinemaName).FirstOrDefault();
            var data3 = db.Producers.Where(x => x.fullName == producerName).FirstOrDefault();
            var data4 = db.Actors.Where(x => x.fullName == actorName).FirstOrDefault();

            var list = db.Cinemas.ToList();
            var list2 = db.Producers.ToList();
            var list3 = db.Actors.ToList();

            ViewBag.cinemaName = new SelectList(list, "name", "name");
            ViewBag.producerName = new SelectList(list2, "fullName", "fullName");
            ViewBag.actorName = new SelectList(list3, "fullName", "fullName");

            ViewBag.cinemaName2 = list;

            var data = db.Movies.ToList();
            List<Movie> newdata = data;

            if (ModelState.IsValid)
            {
                ba.cinemaID = data2.id;
                ba.actorID = data4.id;
                ba.producerID = data3.id;
                db.Movies.Add(ba);
                db.SaveChanges();
            }
            return View(newdata);
        }

        public ActionResult MovieDelete(int id)
        {
            var db2 = db.Movies.Where(x => x.id == id).FirstOrDefault();
            db.Movies.Remove(db2);
            db.SaveChanges();

            return RedirectToAction("Movie", "Management");
        }
    }
}