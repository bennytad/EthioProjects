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
    public class GuestController : Controller
    {
        private DefaultDBContext db = new DefaultDBContext();

        //
        // GET: /Guest/

        public ActionResult Index()
        {
            Object o = System.Web.HttpContext.Current.Session["UserHotelID"];
            Int64 HotelID = o == null ? 0 : (Int64)o;
            var guests = db.Guests.Where(r => r.HotelID == HotelID).Include(g => g.Hotels);
            return View(guests.ToList());
        }

        //
        // GET: /Guest/Details/5

        public ActionResult Details(long id = 0)
        {
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        //
        // GET: /Guest/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Guest/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                Object o = System.Web.HttpContext.Current.Session["UserHotelID"];
                Int64 HotelID = o == null ? 0 : (Int64)o;
                guest.HotelID = HotelID;

                db.Guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName", guest.HotelID);
            return View(guest);
        }

        //
        // GET: /Guest/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName", guest.HotelID);
            return View(guest);
        }

        //
        // POST: /Guest/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "HotelName", guest.HotelID);
            return View(guest);
        }

        //
        // GET: /Guest/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        //
        // POST: /Guest/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Guest guest = db.Guests.Find(id);
            db.Guests.Remove(guest);
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