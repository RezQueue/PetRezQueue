using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RezzQueue.Models
{
    public class PetStatus
    {
        public int PetStatusId { get; set; }
        public int AnimalId { get; set; }
        public int CustomerId { get; set; }
        public bool HasSeen { get; set; }
        public bool Favorite { get; set; }
        public bool ThumbsDown { get; set; }

        //nav property
        //Status(many)-Animal(many)
        public virtual ICollection<Animal> Animals { get; set; }
        //Status(many)-Customer(many)
        public virtual ICollection<Customer> Customers { get; set; }

    }
}