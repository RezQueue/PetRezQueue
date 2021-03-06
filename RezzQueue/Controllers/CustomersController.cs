﻿using System;
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
    public class CustomersController : Controller
    {
        private RezzQueueContext db = new RezzQueueContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
       public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = db.Customers.Find(id);
            List<Animal> FavAnimal = new List<Animal>();
            for (int i = 1; i <= db.PetStatus.Count(); i++)
            {
                PetStatus tempPet = db.PetStatus.Find(i);
                if (tempPet.Favorite == true && tempPet.CustomerId == id)
                {
                    FavAnimal.Add(db.Animals.Find(tempPet.AnimalId));
                }
            }



            CustomerViewModel customerViewModel = new CustomerViewModel
            {
                Customer = customer,
                AllAnimals = FavAnimal
            };


            
            
            return View(customerViewModel);

        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,PetStatusId,Username,Password,ConfirmPassword,CustomerName,EmailID,CustomerLocation")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                
                Animal AnimalHolder = db.Animals.ToList().Last();
                int animalLength = AnimalHolder.AnimalId;
                for (int i = 0; i <= animalLength; i++)
                {
                    
                    Animal AnimalList = db.Animals.Find(i);

                    if (AnimalList == null)
                    {

                    }
                    else
                    {
                        PetStatus CustomerList = new PetStatus();
                        CustomerList.CustomerId = customer.CustomerId;
                        CustomerList.AnimalId = AnimalList.AnimalId;
                        CustomerList.Favorite = false;
                        CustomerList.HasSeen = false;
                        CustomerList.ThumbsDown = false;
                        db.PetStatus.Add(CustomerList);
                        db.SaveChanges();
                    }
                }
                
                db.SaveChanges();
                return RedirectToAction("Index", "Animals", new { page = 1 });
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,PetStatusId,Username,Password,ConfirmPassword,CustomerName,EmailID,CustomerLocation")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
