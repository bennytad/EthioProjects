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
            Object o = System.Web.HttpContext.Current.Session["UserHotelID"];
            Int64 HotelID = o == null ? 0 : (Int64)o;
            var rooms = db.Rooms.Where(p => p.HotelID == HotelID).Include(r => r.RoomTypes);
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
            Object o = System.Web.HttpContext.Current.Session["UserHotelID"];
            Int64 HotelID = o == null ? 0 : (Int64)o;
            var roomtypes = db.RoomTypes.Where(p => p.HotelID == HotelID).Include(r => r.Hotels);

            ViewBag.room_type_id = new SelectList(roomtypes, "room_type_id", "room_type_name");
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
                Int64 HotelID =
                    (Int64)System.Web.HttpContext.Current.Session["UserHotelID"];
                rooms.HotelID = HotelID;
                db.Rooms.Add(rooms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelID = new SelectList(db.RoomTypes, "room_type_id", "room_type_name", rooms.HotelID);
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
            ViewBag.HotelID = new SelectList(db.RoomTypes, "room_type_id", "room_type_name", rooms.HotelID);
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
            ViewBag.HotelID = new SelectList(db.RoomTypes, "room_type_id", "room_type_name", rooms.HotelID);
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