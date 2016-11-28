using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RezzQueue.Models
{
    public class RezzQueueContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RezzQueueContext() : base("name=RezzQueueContext")
        {
        }

        public System.Data.Entity.DbSet<RezzQueue.Models.Animal> Animals { get; set; }

        public System.Data.Entity.DbSet<RezzQueue.Models.Breed> Breeds { get; set; }

        public System.Data.Entity.DbSet<RezzQueue.Models.Species> Species { get; set; }

        public System.Data.Entity.DbSet<RezzQueue.Models.Icon> Icons { get; set; }

        public System.Data.Entity.DbSet<RezzQueue.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<RezzQueue.Models.PetStatus> PetStatus { get; set; }

        public System.Data.Entity.DbSet<RezzQueue.Models.Agency> Agencies { get; set; }
    }
}
