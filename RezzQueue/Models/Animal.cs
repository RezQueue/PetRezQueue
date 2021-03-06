﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RezzQueue.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public int SpeciesId { get; set; }
        public int? BreedId { get; set; }
        public int? IconId { get; set; }
        public string AnimalName { get; set; }
        public int? AnimalAge { get; set; }
        public string AnimalSize { get; set; }
        public int? AnimalPrice { get; set; }
        public string AnimalPreview { get; set; }
        public string AnimalPhoto { get; set; }
        public string AnimalDesc { get; set; }
        public string AnimalLocation { get; set; }
        public int AgencyId { get; set; }
        public string AgencyContact { get; set; }
        
        //nav properties
        //Animal(many) - Species(one)
        public virtual Species Species { get; set; }
        //Animal(many) - Breed(one)
        public virtual Breed Breed { get; set; }
        //Animal(many) - Icon(many)
        public ICollection<Icon> Icons { get; set; }
        //Animal(many) - Customer(many)
        public ICollection<Customer> Customers { get; set; }
        //Animal(many) - Agency(one)
        public virtual Agency Agency { get; set; }



    }
}