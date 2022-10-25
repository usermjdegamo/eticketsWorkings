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
        Database1EntitiesEntities2 db = new Database1EntitiesEntities2();

        // GET: Management
        [HttpGet]
        public ActionResult Actor()
        {
            var data = db.Actors.ToList();
            List<Actor> newdata = data;

            return View(newdata);
        }

        public ActionResult ActorDelete(int id)
        {
            var db2 = db.Actors.Where(x => x.id == id).FirstOrDefault();
            db.Actors.Remove(db2);
            db.SaveChanges();

            return RedirectToAction("Actor", "Management");
        }

        [HttpGet]
        public ActionResult ActorEdit(int id)
        {
            var db2 = db.Actors.Where(x => x.id == id).FirstOrDefault();
            ViewBag.actorProfile = db2.profileURL;
            ViewBag.actorName = db2.fullName;
            ViewBag.actorBio = db2.bio;
            ViewBag.actorID = db2.id;

            //db2.bio = ba.bio;
            //db2.fullName = ba.fullName;
            //db2.profileURL = ba.profileURL;

            return View();
        }

        [HttpPost]
        public ActionResult ActorEdit(int id, Actor ba)
        {
            var db2 = db.Actors.Where(x => x.id == id).FirstOrDefault();

            db2.bio = ba.bio;
            db2.fullName = ba.fullName;
            db2.profileURL = ba.profileURL;
            db.SaveChanges();

            return RedirectToAction("ActorEdit", "Management");
        }

        [HttpGet]
        public ActionResult ActorAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActorAdd(Actor ba)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(ba);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult ActorDetail(int id)
        {
            var db2 = db.Actors.Where(x => x.id == id).FirstOrDefault();
            ViewBag.actorProfile = db2.profileURL;
            ViewBag.actorName = db2.fullName;
            ViewBag.actorBio = db2.bio;
            ViewBag.actorID = db2.id;

            return View();
        }
 
        //Movie
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

        [HttpGet]
        public ActionResult MovieAdd(Movie ba, string cinemaName = null, string producerName = null, string actorName = null)
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

            return View();
        }

        [HttpPost]
        public ActionResult MovieAdd2(Movie ba, string cinemaName = null, string producerName = null, string actorName = null)
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
            return RedirectToAction("MovieAdd", "Management");
        }

        public ActionResult MovieDelete(int id)
        {
            var db2 = db.Movies.Where(x => x.id == id).FirstOrDefault();
            db.Movies.Remove(db2);
            db.SaveChanges();

            return RedirectToAction("Movie", "Management");
        }

        //public ActionResult CinemaDelete(int id)
        //{
        //    var db2 = db.Cinemas.Where(x => x.id == id).FirstOrDefault();
        //    db.Cinemas.Remove(db2);
        //    db.SaveChanges();

        //    return RedirectToAction("Cinema", "Management");
        //}

        //Producer
        [HttpGet]
        public ActionResult Producer()
        {
            var data = db.Producers.ToList();
            List<Producer> newdata = data;

            return View(newdata);
        }

        [HttpGet]
        public ActionResult ProducerAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProducerAdd(Producer ba)
        {

            db.Producers.Add(ba);
            db.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult ProducerEdit(int id)
        {
            var db2 = db.Producers.Where(x => x.id == id).FirstOrDefault();
            ViewBag.ProducerProfile = db2.profileURL;
            ViewBag.ProducerName = db2.fullName;
            ViewBag.ProducerBio = db2.bio;
            ViewBag.ProducerID = db2.id;

            return View();
        }

        [HttpPost]
        public ActionResult ProducerEdit(int id, Producer ba)
        {
            var db2 = db.Producers.Where(x => x.id == id).FirstOrDefault();

            db2.bio = ba.bio;
            db2.fullName = ba.fullName;
            db2.profileURL = ba.profileURL;
            db.SaveChanges();

            return RedirectToAction("ProducerEdit", "Management");
        }

        [HttpGet]
        public ActionResult ProducerDetail(int id)
        {
            var db2 = db.Producers.Where(x => x.id == id).FirstOrDefault();
            ViewBag.ProducerProfile = db2.profileURL;
            ViewBag.ProducerName = db2.fullName;
            ViewBag.ProducerBio = db2.bio;
            ViewBag.ProducerID = db2.id;

            return View();
        }

        public ActionResult ProducerDelete(int id)
        {
            var db2 = db.Producers.Where(x => x.id == id).FirstOrDefault();
            db.Producers.Remove(db2);
            db.SaveChanges();

            return RedirectToAction("Producer", "Management");
        }

        //Cinema
        [HttpGet]
        public ActionResult Cinema()
        {
            var data = db.Cinemas.ToList();
            List<Cinema> newdata = data;

            return View(newdata);
        }

        [HttpGet]
        public ActionResult CinemaAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CinemaAdd(Cinema ba)
        {

            db.Cinemas.Add(ba);
            db.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult CinemaEdit(int id)
        {
            var db2 = db.Cinemas.Where(x => x.id == id).FirstOrDefault();
            ViewBag.CinemaProfile = db2.logo;
            ViewBag.CinemaName = db2.name;
            ViewBag.Cinemadescription = db2.description;
            ViewBag.CinemaID = db2.id;

            return View();
        }

        [HttpPost]
        public ActionResult CinemaEdit(int id, Cinema ba)
        {
            var db2 = db.Cinemas.Where(x => x.id == id).FirstOrDefault();

            db2.description = ba.description;
            db2.name = ba.name;
            db2.logo = ba.logo;
            db.SaveChanges();

            return RedirectToAction("CinemaEdit", "Management");
        }

        [HttpGet]
        public ActionResult CinemaDetail(int id)
        {
            var db2 = db.Cinemas.Where(x => x.id == id).FirstOrDefault();
            ViewBag.CinemaProfile = db2.logo;
            ViewBag.CinemaName = db2.name;
            ViewBag.Cinemadescription = db2.description;
            ViewBag.CinemaID = db2.id;

            return View();
        }

        public ActionResult CinemaDelete(int id)
        {
            var db2 = db.Cinemas.Where(x => x.id == id).FirstOrDefault();
            db.Cinemas.Remove(db2);
            db.SaveChanges();

            return RedirectToAction("Cinema", "Management");
        }
    }
}