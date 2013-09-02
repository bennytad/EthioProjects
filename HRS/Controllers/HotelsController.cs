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
    public class HotelsController : Controller
    {
        private DefaultDBContext db = new DefaultDBContext();

        //
        // GET: /Hotels/

        public ActionResult Index()
        {
            return View(db.Hotels.ToList());
        }

        //
        // GET: /Hotels/Details/5

        public ActionResult Details(Int64 id)
        {
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        //
        // GET: /Hotels/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Hotels/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotels);
        }

        //
        // GET: /Hotels/Edit/5

        public ActionResult Edit(Int64 id)
        {
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        //
        // POST: /Hotels/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotels);
        }

        //
        // GET: /Hotels/Delete/5

        public ActionResult Delete(Int64 id)
        {
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        //
        // POST: /Hotels/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hotels hotels = db.Hotels.Find(id);
            db.Hotels.Remove(hotels);
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