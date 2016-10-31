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
    public class PetStatusController : Controller
    {
        private RezzQueueContext db = new RezzQueueContext();

        // GET: PetStatus
        public ActionResult Index()
        {
            var petStatus = db.PetStatus.Include(p => p.Animal).Include(p => p.Customer);
            return View(petStatus.ToList());
        }

        // GET: PetStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetStatus petStatus = db.PetStatus.Find(id);
            if (petStatus == null)
            {
                return HttpNotFound();
            }
            return View(petStatus);
        }

        // GET: PetStatus/Create
        public ActionResult Create()
        {
            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: PetStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetStatusId,AnimalId,CustomerId,HasSeen,Favorite,ThumbsDown")] PetStatus petStatus)
        {
            if (ModelState.IsValid)
            {
                db.PetStatus.Add(petStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName", petStatus.AnimalId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", petStatus.CustomerId);
            return View(petStatus);
        }

        // GET: PetStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetStatus petStatus = db.PetStatus.Find(id);
            if (petStatus == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName", petStatus.AnimalId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", petStatus.CustomerId);
            return View(petStatus);
        }

        // POST: PetStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetStatusId,AnimalId,CustomerId,HasSeen,Favorite,ThumbsDown")] PetStatus petStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName", petStatus.AnimalId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", petStatus.CustomerId);
            return View(petStatus);
        }

        // GET: PetStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetStatus petStatus = db.PetStatus.Find(id);
            if (petStatus == null)
            {
                return HttpNotFound();
            }
            return View(petStatus);
        }

        // POST: PetStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PetStatus petStatus = db.PetStatus.Find(id);
            db.PetStatus.Remove(petStatus);
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
