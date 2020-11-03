using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saborna_crkva_API.Dtos;
using saborna_crkva_API.Helpers;
using saborna_crkva_API.Models;
using saborna_crkva_API.Services;

namespace saborna_crkva_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ObavjestenjaController : ControllerBase
    {
        private readonly IObavjestenjaService _obavjestenjaService;

        public ObavjestenjaController(IObavjestenjaService obavjestenjaService)
        {
            _obavjestenjaService = obavjestenjaService;
        }

        [AllowAnonymous]
        [HttpGet("getobavjestenja")]
        public ActionResult<PageResult<ObavjestenjeToDisplay>> GetObavjestenja([FromQuery] PageResultQuery pageResultQuery, [FromQuery] int kategorijaId)
        {
            var obavjestenja = _obavjestenjaService.GetObavjestenja(pageResultQuery, kategorijaId);

            if (obavjestenja == null)
            {
                return BadRequest("Nema obavještenja");
            }

            return obavjestenja;
        }

        [AllowAnonymous]
        [HttpGet("getobavjestenja/{id}")]
        public ActionResult<ObavjestenjeToDisplay> GetObavjestenjaById(int id)
        {
            var obavjestenje = _obavjestenjaService.GetObavjestenjeById(id);

            if (obavjestenje == null)
            {
                return BadRequest("Nema obavještenja");
            }

            return obavjestenje;
        }

        [AllowAnonymous]
        [HttpGet("getslike/{id}")]
        public ActionResult<SlikeToDisplay> GetSlike(int id)
        {
            var result = _obavjestenjaService.getSlike(id);

            return result;
        }

        [AllowAnonymous]
        [HttpGet("getkategorije")]
        public ActionResult<List<ObavjestenjaKategorije>> GetKategorije()
        {
            var result = _obavjestenjaService.getKategorije();

            return result;
        }

    }
}