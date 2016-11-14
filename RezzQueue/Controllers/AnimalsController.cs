﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RezzQueue.Models;
using System.IO;

namespace RezzQueue.Controllers
{
    public class AnimalsController : Controller
    {
        private RezzQueueContext db = new RezzQueueContext();

        // GET: Animals
        public ActionResult Index(int? index)
        {
            int max = 3;

            int currentIndex = index.GetValueOrDefault();
            if (currentIndex == 0)
            {
                ViewBag.NetIndex = 1;
            }
            else if (currentIndex >= max)
            {
                currentIndex = max;
                ViewBag.PreviousIndex = currentIndex - 1;
            }
            else
            {
                ViewBag.PreviousIndex = currentIndex - 1;
                ViewBag.NextIndex = currentIndex + 1;
            }
            var animals = db.Animals.Include(a => a.Breed).Include(a => a.Species).Skip(currentIndex).Take(1).FirstOrDefault();
            
            return View(animals);
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName");
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalId,SpeciesId,BreedId,IconId,AnimalName,AnimalAge,AnimalSize,AnimalPrice,AnimalPreview,AnimalPhoto,AnimalDesc,AgencyName,AgencyLocation,AgencyContact")] Animal animal, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)

            {
                db.Animals.Add(animal);
                db.SaveChanges();               
                return RedirectToAction("Index");
            }
                ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName", animal.BreedId);
                ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName", animal.SpeciesId);
                return View(animal);
                
            
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName", animal.BreedId);
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName", animal.SpeciesId);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalId,SpeciesId,BreedId,IconId,AnimalName,AnimalAge,AnimalSize,AnimalPrice,AnimalPreview,AnimalPhoto,AnimalDesc,AgencyName,AgencyLocation,AgencyContact")] Animal animal )
        {
            if (ModelState.IsValid)
            {
               
                
                db.Entry(animal).State = EntityState.Modified;
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName", animal.BreedId);
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName", animal.SpeciesId);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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
