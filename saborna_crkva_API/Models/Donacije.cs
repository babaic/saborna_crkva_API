using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Models
{
    public class Donacije
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public double Iznos { get; set; }
        public string Poruka { get; set; }
        public DateTime Datum { get; set; }
    }
}
