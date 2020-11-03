using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Models
{
    public class ObavjestenjaKategorijeObavjestenja
    {
        public int Id { get; set; }
        public int ObavjestenjaKategorijeID { get; set; }
        public ObavjestenjaKategorije ObavjestenjaKategorije { get; set; }
        public int ObavjestenjaID { get; set; }
        public Obavjestenja Obavjestenja { get; set; }
    }
}
