using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPraktika.Models
{
    public partial class Building
    {
        public Building()
        {
            Cabinets = new HashSet<Cabinet>();
        }

        public int IdBuilding { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cabinet> Cabinets { get; set; }
    }
}
