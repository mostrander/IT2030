using MVCMusicStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        [HttpGet]
        public ActionResult Index(int id)
        {
            MVCMusicStoreDB db = new MVCMusicStoreDB();

            return View(db.Albums.ToList());
        }

         [HttpGet]
         public ActionResult Browse()
         {
            MVCMusicStoreDB db = new MVCMusicStoreDB();

            return View(db.Genres.ToList());
         }

         [HttpGet]
         public ActionResult Details(int id)
         {

            MVCMusicStoreDB db = new MVCMusicStoreDB();

            Album album = db.Albums.Find(id);
           
            return View(album);


         }


    }
}