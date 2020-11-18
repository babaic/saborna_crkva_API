using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Models
{
    public class ObredZahtjev
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ObredKategorijaId { get; set; }
        public ObredKategorija ObredKategorija { get; set; }
        public DateTime Datum { get; set; }
        public string Status { get; set; }
    }
}
