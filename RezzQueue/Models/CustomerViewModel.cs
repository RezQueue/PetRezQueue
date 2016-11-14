﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RezzQueue.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public Animal Animal { get; set; }
        public PetStatus Petstatus { get; set; }
    }
}