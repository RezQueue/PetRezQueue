using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RezzQueue.Models
{
    public class Breed
    {
        public int BreedId { get; set; }
        public string BreedName { get; set; }

        //nav properties

        //breed(one)-animal(many)
        public virtual ICollection<Animal> Animals { get; set; }
    }
}