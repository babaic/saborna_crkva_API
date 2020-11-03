using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Models
{
    public class ObavjestenjaSlike
    {
        public int ObavjestenjaSlikeID { get; set; }
        public byte[] Slika { get; set; }
        public int ObavjestenjaID { get; set; }
        public Obavjestenja Obavjestenja { get; set; }
    }
}
