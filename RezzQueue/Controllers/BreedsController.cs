using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RezzQueue.Models;

namespace RezzQueue.Controllers
{
    public class BreedsController : Controller
    {
        private RezzQueueContext db = new RezzQueueContext();

        // GET: Breeds
        public ActionResult Index()
        {
            var breeds = db.Breeds.Include(b => b.Species);
            return View(breeds.ToList());
        }

        // GET: Breeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Breed breed = db.Breeds.Find(id);
            if (breed == null)
            {
                return HttpNotFound();
            }
            return View(breed);
        }

        // GET: Breeds/Create
        public ActionResult Create()
        {
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName");
            return View();
        }

        // POST: Breeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BreedId,BreedName,SpeciesId")] Breed breed)
        {
            if (ModelState.IsValid)
            {
                db.Breeds.Add(breed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName", breed.SpeciesId);
            return View(breed);
        }

        // GET: Breeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Breed breed = db.Breeds.Find(id);
            if (breed == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName", breed.SpeciesId);
            return View(breed);
        }

        // POST: Breeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BreedId,BreedName,SpeciesId")] Breed breed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(breed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName", breed.SpeciesId);
            return View(breed);
        }

        // GET: Breeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Breed breed = db.Breeds.Find(id);
            if (breed == null)
            {
                return HttpNotFound();
            }
            return View(breed);
        }

        // POST: Breeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Breed breed = db.Breeds.Find(id);
            db.Breeds.Remove(breed);
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
