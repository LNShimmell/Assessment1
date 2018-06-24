using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleReport.Models;

namespace VehicleReport.Controllers
{
    public class VehcilesController : Controller
    {
        private VehicleReportContext db = new VehicleReportContext();

        // GET: Vehciles
        public ActionResult Index()
        {
            var vehciles = db.Vehciles.Include(v => v.Owner);
            return View(vehciles.ToList());
        }

        // GET: Vehciles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehcile vehcile = db.Vehciles.Find(id);
            if (vehcile == null)
            {
                return HttpNotFound();
            }
            return View(vehcile);
        }

        // GET: Vehciles/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "FirstName");
            return View();
        }

        // POST: Vehciles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OwnerId,Make,Model,Year")] Vehcile vehcile)
        {
            if (ModelState.IsValid)
            {
                db.Vehciles.Add(vehcile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "FirstName", vehcile.OwnerId);
            return View(vehcile);
        }

        // GET: Vehciles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehcile vehcile = db.Vehciles.Find(id);
            if (vehcile == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "FirstName", vehcile.OwnerId);
            return View(vehcile);
        }

        // POST: Vehciles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OwnerId,Make,Model,Year")] Vehcile vehcile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehcile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "FirstName", vehcile.OwnerId);
            return View(vehcile);
        }

        // GET: Vehciles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehcile vehcile = db.Vehciles.Find(id);
            if (vehcile == null)
            {
                return HttpNotFound();
            }
            return View(vehcile);
        }

        // POST: Vehciles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehcile vehcile = db.Vehciles.Find(id);
            db.Vehciles.Remove(vehcile);
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
