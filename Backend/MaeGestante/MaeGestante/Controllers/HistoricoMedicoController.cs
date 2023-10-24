using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoMedicoController : ControllerBase
    {
        private readonly HistoricoMedicoService _historicoMedicoService;

        public HistoricoMedicoController(HistoricoMedicoService historicoMedicoService)
        {
            _historicoMedicoService = historicoMedicoService;
        }

        [HttpGet("gestante/{gestanteId}")]
        public async Task<ActionResult<IEnumerable<HistoricoMedico>>> GetHistoricoMedicoByGestanteId(int gestanteId)
        {
            var historicoMedico = await _historicoMedicoService.GetHistoricoMedicoByGestanteIdAsync(gestanteId);

            if (historicoMedico == null)
            {
                return NotFound();
            }

            return Ok(historicoMedico);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHistoricoMedico([FromBody] HistoricoMedico historicoMedico)
        {
            try
            {
                await _historicoMedicoService.CreateHistoricoMedicoAsync(historicoMedico);
                return CreatedAtAction(nameof(GetHistoricoMedicoByGestanteId), new { gestanteId = historicoMedico.GestanteID }, historicoMedico);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHistoricoMedico(int id, [FromBody] HistoricoMedico historicoMedico)
        {
            if (id != historicoMedico.ID)
            {
                return BadRequest();
            }

            try
            {
                await _historicoMedicoService.UpdateHistoricoMedicoAsync(historicoMedico);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
