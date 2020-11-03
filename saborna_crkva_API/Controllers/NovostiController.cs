using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saborna_crkva_API.Dtos;
using saborna_crkva_API.Helpers;
using saborna_crkva_API.Services;

namespace saborna_crkva_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NovostiController : ControllerBase
    {
        private readonly INovostiService _novostiService;

        public NovostiController(INovostiService novostiService)
        {
            _novostiService = novostiService;
        }

        [AllowAnonymous]
        [HttpGet("getnovosti")]
        public ActionResult<PageResult<NovostiToDisplay>> GetNovosti([FromQuery] PageResultQuery pageResultQuery, [FromQuery] int id)
        {
            var novosti = _novostiService.getNovosti(pageResultQuery, id);

            if(novosti == null)
            {
                return BadRequest("Nema novosti");
            }

            return novosti;
        }

        [AllowAnonymous]
        [HttpGet("getslike/{id}")]
        public ActionResult<SlikeToDisplay> GetSlike(int id)
        {
            var result = _novostiService.getSlike(id);

            return result;
        }
    }
}