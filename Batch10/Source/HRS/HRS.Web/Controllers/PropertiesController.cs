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
    public class PropertiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Properties
        public ActionResult Index()
        {
            var property = db.Property.Include(p => p.City).Include(p => p.Country).Include(p => p.PropertyType).Include(p => p.Rating);
            return View(property.ToList());
        }

        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Property.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.City, "Id", "CityName");
            ViewBag.CountryId = new SelectList(db.Country, "Id", "Name");
            ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "PropType");
            ViewBag.RatingId = new SelectList(db.Rating, "Id", "StarRating");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CountryId,CityId,PropertyTypeId,PropertyName,PropertyAdd,PropertyDesc,RatingId,Facilities,Image")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Property.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.City, "Id", "CityName", property.CityId);
            ViewBag.CountryId = new SelectList(db.Country, "Id", "Name", property.CountryId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "PropType", property.PropertyTypeId);
            ViewBag.RatingId = new SelectList(db.Rating, "Id", "StarRating", property.RatingId);
            return View(property);
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Property.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.City, "Id", "CityName", property.CityId);
            ViewBag.CountryId = new SelectList(db.Country, "Id", "Name", property.CountryId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "PropType", property.PropertyTypeId);
            ViewBag.RatingId = new SelectList(db.Rating, "Id", "StarRating", property.RatingId);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CountryId,CityId,PropertyTypeId,PropertyName,PropertyAdd,PropertyDesc,RatingId,Facilities,Image")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.City, "Id", "CityName", property.CityId);
            ViewBag.CountryId = new SelectList(db.Country, "Id", "Name", property.CountryId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "PropType", property.PropertyTypeId);
            ViewBag.RatingId = new SelectList(db.Rating, "Id", "StarRating", property.RatingId);
            return View(property);
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Property.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Property.Find(id);
            db.Property.Remove(property);
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
