using Microsoft.EntityFrameworkCore;
using saborna_crkva_API.Dtos;
using saborna_crkva_API.EF;
using saborna_crkva_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Services
{
    public class ObredService : IObredService
    {
        private readonly MyContext _context;
        public ObredService(MyContext context)
        {
            _context = context;
        }

        public int AddObred(ObredZahtjev obredToAdd)
        {
            var obred = new ObredZahtjev
            {
                Datum = DateTime.Now,
                ObredKategorijaId = obredToAdd.ObredKategorijaId,
                UserId = obredToAdd.UserId
            };
            _context.Add(obred);
            _context.SaveChanges();
            return obred.Id;
        }

        public List<ObredToDisplay> GetObredi(string status, int userid = 0)
        {
            List<ObredToDisplay> obredi = new List<ObredToDisplay>();
            var query = _context.ObredZahtjev.Include(x => x.ObredKategorija).Include(x => x.User)
                .Select(x=> new ObredToDisplay
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Datum = x.Datum,
                    ImePrezime = x.User.Ime + " " + x.User.Prezime,
                    Kategorija = x.ObredKategorija.Naziv,
                    Status = x.Status
                }).OrderByDescending(x=>x.Id)
                .AsQueryable();

            if (userid != 0)
            {
                query = query.Where(x => x.UserId == userid);
            }

            if(status != null)
            {
                query = query.Where(x => x.Status == status);
            }

            var result = query.ToList();

            return result;
        }

        public List<ObredKategorija> GetObrediKategorije()
        {
            return _context.ObredKategorija.ToList();
        }

        public async Task updateStatus(int obredId, string status)
        {
            var obred = _context.ObredZahtjev.FirstOrDefault(x=> x.Id == obredId);
            obred.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
