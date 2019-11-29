using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IT2030_MeganOstrander_FinalProject.Models;

namespace IT2030_MeganOstrander_FinalProject.Controllers
{
    public class EventStoreController : Controller
    {
        private EventsDBContext db = new EventsDBContext();

        // GET: EventStore
        public ActionResult Index()
        {
            var events = db.Events.Include(a => a.Type).Include(a => a.Organizer)
            .OrderBy(a => a.StartDate)
            ;
            return View(events.ToList());
        }

      // GET: EventStore FOR UPCOMING events
      public ActionResult UpcomingEvents()
      {
         var events = db.Events.Include(a => a.Type).Include(a => a.Organizer)
            .Where(a => a.StartDate > DateTime.Now)
            .OrderBy(a => a.StartDate)
         ;
         return View(events.ToList());
      }


      public ActionResult EventSearch (string q)
      {
         var events = GetEvents(q);

         return PartialView("_EventSearch", events);
      }

      private List<Event> GetEvents(string searchString)
      {
         return db.Events
            .Where(a => a.Type.Name.Contains(searchString) || a.Title.Contains(searchString))
            .OrderBy(a => a.StartDate)
            .ToList();
      }


      // GET: EventStore/Details/5
      public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        
        // GET: EventStore/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.OrganizerId = new SelectList(db.Organizers, "OrganizerId", "Name");
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name");
            return View();
        }

        // POST: EventStore/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,TypeId,OrganizerId,Title,StartDate,StartTime,EndDate,EndTime,Location,Description,MaxTickets,AvailableTickets")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizerId = new SelectList(db.Organizers, "OrganizerId", "Name", @event.OrganizerId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", @event.TypeId);
            return View(@event);
        }


        // GET: EventStore/Edit/5 
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizerId = new SelectList(db.Organizers, "OrganizerId", "Name", @event.OrganizerId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", @event.TypeId);
            return View(@event);
        }

        
        // POST: EventStore/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,TypeId,OrganizerId,Title,StartDate,StartTime,EndDate,EndTime,Location,Description,MaxTickets,AvailableTickets")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizerId = new SelectList(db.Organizers, "OrganizerId", "Name", @event.OrganizerId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name", @event.TypeId);
            return View(@event);
        }

        // GET: EventStore/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: EventStore/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
