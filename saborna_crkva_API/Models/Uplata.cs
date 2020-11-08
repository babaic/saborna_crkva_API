using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Models
{
    public class Uplata
    {
        public string ChargeId { get; set; }
        public float UplacenoUkupno { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
