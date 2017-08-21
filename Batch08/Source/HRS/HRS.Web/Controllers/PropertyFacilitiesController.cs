using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRS.Web.Models;

namespace HRS.Web.Controllers
{
    public class PropertyFacilitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PropertyFacilities
        public ActionResult Index()
        {
            return View(db.PropertyFacility.ToList());
        }

        // GET: PropertyFacilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyFacility propertyFacility = db.PropertyFacility.Find(id);
            if (propertyFacility == null)
            {
                return HttpNotFound();
            }
            return View(propertyFacility);
        }

        // GET: PropertyFacilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyFacilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FacilitiesName")] PropertyFacility propertyFacility)
        {
            if (ModelState.IsValid)
            {
                db.PropertyFacility.Add(propertyFacility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyFacility);
        }

        // GET: PropertyFacilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyFacility propertyFacility = db.PropertyFacility.Find(id);
            if (propertyFacility == null)
            {
                return HttpNotFound();
            }
            return View(propertyFacility);
        }

        // POST: PropertyFacilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FacilitiesName")] PropertyFacility propertyFacility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyFacility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyFacility);
        }

        // GET: PropertyFacilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyFacility propertyFacility = db.PropertyFacility.Find(id);
            if (propertyFacility == null)
            {
                return HttpNotFound();
            }
            return View(propertyFacility);
        }

        // POST: PropertyFacilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyFacility propertyFacility = db.PropertyFacility.Find(id);
            db.PropertyFacility.Remove(propertyFacility);
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
