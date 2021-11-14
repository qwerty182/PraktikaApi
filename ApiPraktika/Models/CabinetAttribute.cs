using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPraktika.Models
{
    public partial class CabinetAttribute
    {
        public CabinetAttribute()
        {
            CabinetCompositions = new HashSet<CabinetComposition>();
        }

        public int IdAttribute { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CabinetComposition> CabinetCompositions { get; set; }
    }
}
