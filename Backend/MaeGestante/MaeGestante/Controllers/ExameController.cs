using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly ExameService _exameService;

        public ExameController(ExameService exameService)
        {
            _exameService = exameService;
        }

        [HttpGet("gestante/{gestanteId}")]
        public async Task<ActionResult<IEnumerable<Exame>>> GetExamesByGestanteId(int gestanteId)
        {
            var exames = await _exameService.GetExamesByGestanteIdAsync(gestanteId);

            if (exames == null)
            {
                return NotFound();
            }

            return Ok(exames);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExame([FromBody] Exame exame)
        {
            try
            {
                await _exameService.CreateExameAsync(exame);
                return CreatedAtAction(nameof(GetExameById), new { id = exame.ID }, exame);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExame(int id, [FromBody] Exame exame)
        {
            if (id != exame.ID)
            {
                return BadRequest();
            }

            try
            {
                await _exameService.UpdateExameAsync(exame);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exame>> GetExameById(int id)
        {
            var exame = await _exameService.GetExameByIdAsync(id);

            if (exame == null)
            {
                return NotFound();
            }

            return Ok(exame);
        }
    }
}
