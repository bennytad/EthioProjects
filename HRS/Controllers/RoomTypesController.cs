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
    public class RoomTypesController : Controller
    {
        private DefaultDBContext db = new DefaultDBContext();

        //
        // GET: /RoomTypes/

        public ActionResult Index()
        {
            var roomtypes = db.RoomTypes.Include(r => r.Hotels);
            return View(roomtypes.ToList());
        }

        //
        // GET: /RoomTypes/Details/5

        public ActionResult Details(long id = 0)
        {
            RoomTypes roomtypes = db.RoomTypes.Find(id);
            if (roomtypes == null)
            {
                return HttpNotFound();
            }
            return View(roomtypes);
        }

        //
        // GET: /RoomTypes/Create

        public ActionResult Create()
        {
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName");
            return View();
        }

        //
        // POST: /RoomTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomTypes roomtypes)
        {
            if (ModelState.IsValid)
            {
                db.RoomTypes.Add(roomtypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName", roomtypes.HotelID);
            return View(roomtypes);
        }

        //
        // GET: /RoomTypes/Edit/5

        public ActionResult Edit(long id = 0)
        {
            RoomTypes roomtypes = db.RoomTypes.Find(id);
            if (roomtypes == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName", roomtypes.HotelID);
            return View(roomtypes);
        }

        //
        // POST: /RoomTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomTypes roomtypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomtypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName", roomtypes.HotelID);
            return View(roomtypes);
        }

        //
        // GET: /RoomTypes/Delete/5

        public ActionResult Delete(long id = 0)
        {
            RoomTypes roomtypes = db.RoomTypes.Find(id);
            if (roomtypes == null)
            {
                return HttpNotFound();
            }
            return View(roomtypes);
        }

        //
        // POST: /RoomTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            RoomTypes roomtypes = db.RoomTypes.Find(id);
            db.RoomTypes.Remove(roomtypes);
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