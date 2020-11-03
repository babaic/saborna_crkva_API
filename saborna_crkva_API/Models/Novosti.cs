using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Models
{
    public class Novosti
    {
        public int NovostiID { get; set; }
        public string Text { get; set; }
        public byte[] Slika { get; set; }
        public DateTime DatumObjavljivanja { get; set; }
        public string Naslov { get; set; }
    }
}
