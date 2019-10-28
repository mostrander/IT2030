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
        // Shows albums by requested Genre
        [HttpGet]
        public ActionResult Index(int id)
        {
            MVCMusicStoreDB db = new MVCMusicStoreDB();

         return View (db.Albums
            .Where(a => a.GenreId.Equals(id))
            .OrderBy(a => a.Title)
            .ToList());

        }



         [HttpGet]
         public ActionResult Browse()
         {
            MVCMusicStoreDB db = new MVCMusicStoreDB();

            return View(db.Genres
               .OrderBy(a => a.Name)
               .ToList());

         }



         //gets specific album
         [HttpGet]
         public ActionResult Details(int id)
         {

            MVCMusicStoreDB db = new MVCMusicStoreDB();

            Album album = db.Albums.Find(id);

            return View(album);



         }


    }
}