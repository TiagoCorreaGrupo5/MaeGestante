using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalSaudeController : ControllerBase
    {
        private readonly ProfissionalSaudeService _profissionalSaudeService;

        public ProfissionalSaudeController(ProfissionalSaudeService profissionalSaudeService)
        {
            _profissionalSaudeService = profissionalSaudeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfissionalSaude>> GetProfissionalSaude(int id)
        {
            var profissionalSaude = await _profissionalSaudeService.GetProfissionalSaudeByIdAsync(id);

            if (profissionalSaude == null)
            {
                return NotFound();
            }

            return Ok(profissionalSaude);
        }

        [HttpGet("especialidade/{especialidadeId}")]
        public async Task<ActionResult<IEnumerable<ProfissionalSaude>>> GetProfissionaisSaudeByEspecialidade(int especialidadeId)
        {
            var profissionaisSaude = await _profissionalSaudeService.GetProfissionaisSaudeByEspecialidadeAsync(especialidadeId);
            return Ok(profissionaisSaude);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProfissionalSaude([FromBody] ProfissionalSaude profissionalSaude)
        {
            try
            {
                await _profissionalSaudeService.CreateProfissionalSaudeAsync(profissionalSaude);
                return CreatedAtAction(nameof(GetProfissionalSaude), new { id = profissionalSaude.ID }, profissionalSaude);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProfissionalSaude(int id, [FromBody] ProfissionalSaude profissionalSaude)
        {
            if (id != profissionalSaude.ID)
            {
                return BadRequest();
            }

            try
            {
                await _profissionalSaudeService.UpdateProfissionalSaudeAsync(profissionalSaude);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfissionalSaude(int id)
        {
            try
            {
                await _profissionalSaudeService.DeleteProfissionalSaudeAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
