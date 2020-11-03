using saborna_crkva_API.Dtos;
using saborna_crkva_API.Helpers;
using saborna_crkva_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Services
{
    public interface IObavjestenjaService
    {
        PageResult<ObavjestenjeToDisplay> GetObavjestenja(PageResultQuery pageResultQuery, int kategorijaId);
        ObavjestenjeToDisplay GetObavjestenjeById(int id);
        SlikeToDisplay getSlike(int obavjestenjeid);
        List<ObavjestenjaKategorije> getKategorije();
    }
}
