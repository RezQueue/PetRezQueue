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
        //Status(many)-Animal(one)
        public virtual Animal Animal { get; set; }
        //Status(many)-Customer(one)
        public virtual Customer Customer { get; set; }

    }
}