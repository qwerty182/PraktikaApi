using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPraktika.Models
{
    public partial class Cabinet
    {
        public Cabinet()
        {
            CabinetCompositions = new HashSet<CabinetComposition>();
            Reports = new HashSet<Report>();
        }

        public int IdCabinet { get; set; }
        public string CabinetNumber { get; set; }
        public string CabinetImage { get; set; }
        public string GeneralInformation { get; set; }
        public int? BuildingId { get; set; }

        public virtual Building Building { get; set; }
        public virtual ICollection<CabinetComposition> CabinetCompositions { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
