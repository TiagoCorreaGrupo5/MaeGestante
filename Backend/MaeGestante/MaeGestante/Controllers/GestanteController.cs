using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestanteController : ControllerBase
    {
        private readonly GestanteService _gestanteService;

        public GestanteController(GestanteService gestanteService)
        {
            _gestanteService = gestanteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gestante>>> GetAllGestantes()
        {
            var gestantes = await _gestanteService.GetAllGestantesAsync();
            return Ok(gestantes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gestante>> GetGestanteById(int id)
        {
            var gestante = await _gestanteService.GetGestanteByIdAsync(id);

            if (gestante == null)
            {
                return NotFound();
            }

            return Ok(gestante);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGestante([FromBody] Gestante gestante)
        {
            try
            {
                await _gestanteService.CreateGestanteAsync(gestante);
                return CreatedAtAction(nameof(GetGestanteById), new { id = gestante.ID }, gestante);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGestante(int id, [FromBody] Gestante gestante)
        {
            if (id != gestante.ID)
            {
                return BadRequest();
            }

            try
            {
                await _gestanteService.UpdateGestanteAsync(gestante);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGestante(int id)
        {
            try
            {
                await _gestanteService.DeleteGestanteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
