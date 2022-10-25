using ET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ET.Controllers
{
    public class HomeController : Controller
    {
        Database1EntitiesEntities2 db = new Database1EntitiesEntities2();

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            var data = db.Movies.ToList();
            List<Movie> newdata = data;

            return View(newdata);
        }

        //[HttpPost]
        //public ActionResult Index(Movie x)
        //{
        //    var data = db.Movies.ToList();
        //    List<Movie> newdata = data;

        //    if (ModelState.IsValid)
        //    {
        //        db.Movies.Add(x);
        //        db.SaveChanges();
        //    }

        //    return View(newdata);
        //}

    }
}