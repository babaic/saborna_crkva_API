using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saborna_crkva_API.Dtos;
using saborna_crkva_API.Models;
using saborna_crkva_API.Services;

namespace saborna_crkva_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ObrediController : ControllerBase
    {
        private readonly IObredService _obredService;

        public ObrediController(IObredService obredService)
        {
            _obredService = obredService;
        }

        [AllowAnonymous]
        [HttpPost("addobred")]
        public ActionResult AddObred(ObredZahtjev obredToAdd)
        {
            var result = _obredService.AddObred(obredToAdd);
            var obj = new Dictionary<String, int>();
            obj.Add("obredId", result);

            return Ok(obj);
        }

        [AllowAnonymous]
        [HttpGet("getobredi")]
        public ActionResult<List<ObredToDisplay>> GetObredi([FromQuery] string status, [FromQuery] int userid)
        {
            var result = _obredService.GetObredi(status, userid);

            return result;
        }

        [AllowAnonymous]
        [HttpGet("getobredikategorije")]
        public ActionResult<List<ObredKategorija>> GetObrediKategorije([FromQuery] int userid)
        {
            return _obredService.GetObrediKategorije();
        }

        [AllowAnonymous]
        [HttpPut("updatestatus/{id}")]
        public async Task<ActionResult> UpdateStatusAsync(int id, ObredZahtjev obred)
        {
            await _obredService.updateStatus(id, obred.Status);
            return Ok();
        }
    }
}