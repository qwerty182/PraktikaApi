using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPraktika.Models
{
    public partial class Report
    {
        public int IdReport { get; set; }
        public string Comment { get; set; }
        public string Images { get; set; }
        public DateTime DateOfLocations { get; set; }
        public bool Status { get; set; }
        public int? UserId { get; set; }
        public int? CabinetId { get; set; }
        public int? ReportTypeId { get; set; }

        public virtual Cabinet Cabinet { get; set; }
        public virtual ReportType ReportType { get; set; }
        public virtual User User { get; set; }
    }
}
