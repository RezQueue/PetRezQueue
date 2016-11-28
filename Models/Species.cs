using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RezzQueue.Models
{
    public class Species
    {
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; }

        //nav properties

        //species(one) - animal(many)
        public virtual ICollection<Animal> Animals { get; set; }
        //species(one) - breed (many)
        public virtual ICollection<Breed> Breeds { get; set; }
    }
}