using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Dtos
{
    public class ObredToDisplay
    {
        public int Id { get; set; }
        public string Kategorija { get; set; }
        public string ImePrezime { get; set; }
        public int UserId { get; set; }
        public DateTime Datum { get; set; }
        public string Status { get; set; }
    }
}
