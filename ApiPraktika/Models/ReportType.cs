using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPraktika.Models
{
    public partial class ReportType
    {
        public ReportType()
        {
            Reports = new HashSet<Report>();
        }

        public int IdReportType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
