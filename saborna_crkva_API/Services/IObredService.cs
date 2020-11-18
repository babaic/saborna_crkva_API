using saborna_crkva_API.Dtos;
using saborna_crkva_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Services
{
    public interface IObredService
    {
        List<ObredToDisplay> GetObredi(string status, int userid = 0);
        int AddObred(ObredZahtjev obred);
        List<ObredKategorija> GetObrediKategorije();
        Task updateStatus(int obredId, string status);
    }
}
