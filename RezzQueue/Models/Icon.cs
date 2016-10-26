using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RezzQueue.Models
{
    public class Icon
    {
        public int IconId { get; set; }
        public string IconName { get; set; }
        public string IconGlyph { get; set; }

        //nav property
        //icon(many) - animal(many)
        public virtual ICollection<Animal> Animals { get; set; }
    }
}