using saborna_crkva_API.Dtos;
using saborna_crkva_API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Services
{
    public interface INovostiService
    {
        PageResult<NovostiToDisplay> getNovosti(PageResultQuery pageResultQuery, int? id);
        SlikeToDisplay getSlike(int novostid);

    }
}
