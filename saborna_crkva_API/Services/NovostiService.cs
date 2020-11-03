using saborna_crkva_API.Dtos;
using saborna_crkva_API.EF;
using saborna_crkva_API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Services
{
    public class NovostiService : INovostiService
    {
        private readonly MyContext _context;

        public NovostiService(MyContext context)
        {
            _context = context;
        }

        public PageResult<NovostiToDisplay> getNovosti(PageResultQuery pageResultQuery, int? id = 0)
        {
            var query = _context.Novosti.OrderByDescending(x=>x.NovostiID).Select(x => new NovostiToDisplay
            {
                Id = x.NovostiID,
                Naslov = x.Naslov,
                Text = x.Text,
                DatumObjavljivanja = x.DatumObjavljivanja,
                GlavnaSlika = x.Slika,
            }).AsQueryable();

            if(id != 0)
            {
                query = query.Where(x => x.Id == id);
            }

            var novosti = query.ToList();

            var result = new PageResult<NovostiToDisplay>
            {
                Count = novosti.Count,
                PageIndex = pageResultQuery.PageNumber,
                PageSize = pageResultQuery.PageSize,
                Items = novosti.Skip((pageResultQuery.PageNumber - 1) * pageResultQuery.PageSize).Take(pageResultQuery.PageSize).ToList(),
                TotalPage = (int)Math.Ceiling((double)novosti.Count / pageResultQuery.PageSize)
            };

            return result;
        }

        public SlikeToDisplay getSlike(int novostid)
        {
            SlikeToDisplay slike = new SlikeToDisplay
            {
                Slike = _context.NovostiSlike.Where(x => x.NovostiID == novostid).Select(x => x.Slika).ToList()
            };

            return slike;
        }
    }
}
