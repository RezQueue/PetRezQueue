using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RezzQueue.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Animal> AllAnimals { get; set; }
        public IEnumerable<PetStatus> PetStatus { get; set; }
        

    }
}
