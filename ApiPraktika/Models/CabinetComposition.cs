using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPraktika.Models
{
    public partial class CabinetComposition
    {
        public int IdCabinetCompositions { get; set; }
        public string Value { get; set; }
        public int? CabinetId { get; set; }
        public int? AttributeId { get; set; }

        public virtual CabinetAttribute Attribute { get; set; }
        public virtual Cabinet Cabinet { get; set; }
    }
}
