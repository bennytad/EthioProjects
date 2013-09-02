using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRS.Models;

namespace HRS.Controllers
{
    public class RoomsController : Controller
    {
        private DefaultDBContext db = new DefaultDBContext();

        //
        // GET: /Rooms/

        public ActionResult Index()
        {
            var rooms = db.Rooms.Include(r => r.Hotels).Include(r => r.RoomTypes);
            return View(rooms.ToList());
        }

        //
        // GET: /Rooms/Details/5

        public ActionResult Details(long id = 0)
        {
            Rooms rooms = db.Rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            return View(rooms);
        }

        //
        // GET: /Rooms/Create

        public ActionResult Create()
        {
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName");
            ViewBag.room_type_id = new SelectList(db.RoomTypes, "room_type_id", "room_type_name");
            return View();
        }

        //
        // POST: /Rooms/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(rooms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName", rooms.HotelID);
            ViewBag.room_type_id = new SelectList(db.RoomTypes, "room_type_id", "room_type_name", rooms.room_type_id);
            return View(rooms);
        }

        //
        // GET: /Rooms/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Rooms rooms = db.Rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName", rooms.HotelID);
            ViewBag.room_type_id = new SelectList(db.RoomTypes, "room_type_id", "room_type_name", rooms.room_type_id);
            return View(rooms);
        }

        //
        // POST: /Rooms/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName", rooms.HotelID);
            ViewBag.room_type_id = new SelectList(db.RoomTypes, "room_type_id", "room_type_name", rooms.room_type_id);
            return View(rooms);
        }

        //
        // GET: /Rooms/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Rooms rooms = db.Rooms.Find(id);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            return View(rooms);
        }

        //
        // POST: /Rooms/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Rooms rooms = db.Rooms.Find(id);
            db.Rooms.Remove(rooms);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}