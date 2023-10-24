using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly ReceitaService _receitaService;

        public ReceitaController(ReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> GetReceita(int id)
        {
            var receita = await _receitaService.GetReceitaByIdAsync(id);

            if (receita == null)
            {
                return NotFound();
            }

            return Ok(receita);
        }

        [HttpGet("gestante/{gestanteId}")]
        public async Task<ActionResult<IEnumerable<Receita>>> GetReceitasByGestanteId(int gestanteId)
        {
            var receitas = await _receitaService.GetReceitasByGestanteIdAsync(gestanteId);
            return Ok(receitas);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReceita([FromBody] Receita receita)
        {
            try
            {
                await _receitaService.CreateReceitaAsync(receita);
                return CreatedAtAction(nameof(GetReceita), new { id = receita.ID }, receita);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReceita(int id, [FromBody] Receita receita)
        {
            if (id != receita.ID)
            {
                return BadRequest();
            }

            try
            {
                await _receitaService.UpdateReceitaAsync(receita);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
