using Microsoft.EntityFrameworkCore;
using saborna_crkva_API.Dtos;
using saborna_crkva_API.EF;
using saborna_crkva_API.Helpers;
using saborna_crkva_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Services
{
    public class ObavjestenjaService : IObavjestenjaService
    {
        private readonly MyContext _context;
        public ObavjestenjaService(MyContext context)
        {
            _context = context;
        }

        public List<ObavjestenjaKategorije> getKategorije()
        {
            return _context.ObavjestenjaKategorije.ToList();
        }

        public PageResult<ObavjestenjeToDisplay> GetObavjestenja(PageResultQuery pageResultQuery, int kategorijaId)
        {
            var query = _context.ObavjestenjaKategorijeObavjestenja.Include(x => x.Obavjestenja).Include(x => x.ObavjestenjaKategorije)
                .Where(x => x.ObavjestenjaKategorijeID == kategorijaId).OrderByDescending(x=>x.ObavjestenjaID).Select(x => new ObavjestenjeToDisplay
            {
                Id = x.ObavjestenjaID,
                Naslov = x.Obavjestenja.Naslov,
                Text = x.Obavjestenja.Text,
                DatumObjavljivanja = x.Obavjestenja.DatumObjavljivanja,
                GlavnaSlika = x.Obavjestenja.Slika,
                Kategorije = _context.ObavjestenjaKategorije.Where(c => c.ObavjestenjaKategorijeID == kategorijaId).ToList(),
            }).AsQueryable();

            var obavjestenja = query.ToList();

            var result = new PageResult<ObavjestenjeToDisplay>
            {
                Count = obavjestenja.Count,
                PageIndex = pageResultQuery.PageNumber,
                PageSize = pageResultQuery.PageSize,
                Items = obavjestenja.Skip((pageResultQuery.PageNumber - 1) * pageResultQuery.PageSize).Take(pageResultQuery.PageSize).ToList(),
                TotalPage = (int)Math.Ceiling((double)obavjestenja.Count / pageResultQuery.PageSize)
            };

            return result;
        }

        public ObavjestenjeToDisplay GetObavjestenjeById(int id)
        {
            var obavjestenje = _context.ObavjestenjaKategorijeObavjestenja.Include(x => x.Obavjestenja).Include(x => x.ObavjestenjaKategorije).Where(x => x.ObavjestenjaID == id)
                .Select(x => new ObavjestenjeToDisplay
                {
                    Id = x.ObavjestenjaID,
                    Naslov = x.Obavjestenja.Naslov,
                    Text = x.Obavjestenja.Text,
                    DatumObjavljivanja = x.Obavjestenja.DatumObjavljivanja,
                    GlavnaSlika = x.Obavjestenja.Slika,
                    Kategorije = _context.ObavjestenjaKategorije.Where(c => c.ObavjestenjaKategorijeID == x.ObavjestenjaKategorije.ObavjestenjaKategorijeID).ToList(),
                    Slike = _context.ObavjestenjaSlike.Where(c => c.ObavjestenjaID == id).Select(c => c.Slika).ToList()
                }).FirstOrDefault();

            return obavjestenje;
        }

        public SlikeToDisplay getSlike(int obavjestenjeid)
        {
            SlikeToDisplay slike = new SlikeToDisplay
            {
                Slike = _context.ObavjestenjaSlike.Where(x => x.ObavjestenjaID == obavjestenjeid).Select(x => x.Slika).ToList()
            };

            return slike;
        }
    }
}
