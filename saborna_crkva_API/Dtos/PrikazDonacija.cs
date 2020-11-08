using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Dtos
{
    public class PrikazDonacija
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public double Iznos { get; set; }
        public string Poruka { get; set; }
        public string ImePrezime { get; set; }
        public int UserId { get; set; }
    }
}
