using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaService _consultaService;

        public ConsultaController(ConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet("gestante/{gestanteId}")]
        public async Task<ActionResult<IEnumerable<Consulta>>> GetConsultasByGestanteId(int gestanteId)
        {
            var consultas = await _consultaService.GetConsultasByGestanteIdAsync(gestanteId);

            if (consultas == null)
            {
                return NotFound();
            }

            return Ok(consultas);
        }

        [HttpGet("profissional/{profissionalId}")]
        public async Task<ActionResult<IEnumerable<Consulta>>> GetConsultasByProfissionalId(int profissionalId)
        {
            var consultas = await _consultaService.GetConsultasByProfissionalIdAsync(profissionalId);

            if (consultas == null)
            {
                return NotFound();
            }

            return Ok(consultas);
        }

        [HttpPost]
        public async Task<ActionResult> CreateConsulta([FromBody] Consulta consulta)
        {
            try
            {
                await _consultaService.CreateConsultaAsync(consulta);
                return CreatedAtAction(nameof(GetConsultasByGestanteId), new { gestanteId = consulta.GestanteID }, consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateConsulta(int id, [FromBody] Consulta consulta)
        {
            if (id != consulta.ID)
            {
                return BadRequest();
            }

            try
            {
                await _consultaService.UpdateConsultaAsync(consulta);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
