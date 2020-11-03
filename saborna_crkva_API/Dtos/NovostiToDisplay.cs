using saborna_crkva_API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Dtos
{
    public class NovostiToDisplay : PageResultQuery
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Text { get; set; }
        public DateTime DatumObjavljivanja { get; set; }
        public byte[] GlavnaSlika { get; set; }
        public List<byte[]> Slike { get; set; }
    }
}
