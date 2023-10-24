using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaEspecialistaController : ControllerBase
    {
        private readonly AgendaEspecialistaService _agendaEspecialistaService;

        public AgendaEspecialistaController(AgendaEspecialistaService agendaEspecialistaService)
        {
            _agendaEspecialistaService = agendaEspecialistaService;
        }

        [HttpGet("profissional/{profissionalId}")]
        public async Task<ActionResult<IEnumerable<AgendaEspecialista>>> GetAgendaByProfissionalId(int profissionalId)
        {
            var agendaEspecialista = await _agendaEspecialistaService.GetAgendaByProfissionalIdAsync(profissionalId);

            if (agendaEspecialista == null)
            {
                return NotFound();
            }

            return Ok(agendaEspecialista);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAgendaEspecialista([FromBody] AgendaEspecialista agendaEspecialista)
        {
            try
            {
                await _agendaEspecialistaService.CreateAgendaEspecialistaAsync(agendaEspecialista);
                return CreatedAtAction(nameof(GetAgendaByProfissionalId), new { profissionalId = agendaEspecialista.ProfissionalID }, agendaEspecialista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAgendaEspecialista(int id, [FromBody] AgendaEspecialista agendaEspecialista)
        {
            if (id != agendaEspecialista.ID)
            {
                return BadRequest();
            }

            try
            {
                await _agendaEspecialistaService.UpdateAgendaEspecialistaAsync(agendaEspecialista);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAgendaEspecialista(int id)
        {
            try
            {
                await _agendaEspecialistaService.DeleteAgendaEspecialistaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
