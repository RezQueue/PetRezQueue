using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RezzQueue.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int PetStatusId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLocation { get; set; }
        

        //nav property
        //customer(many) - animal(many)
        public virtual ICollection<Animal> Animals { get; set; }
        //Customer(many)-Status(many)
        public ICollection<PetStatus> PetStatuses { get; set; }
    }
}