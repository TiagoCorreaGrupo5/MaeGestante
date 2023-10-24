using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiasFolgaController : ControllerBase
    {
        private readonly DiasFolgaService _diasFolgaService;

        public DiasFolgaController(DiasFolgaService diasFolgaService)
        {
            _diasFolgaService = diasFolgaService;
        }

        [HttpGet("profissional/{profissionalId}")]
        public async Task<ActionResult<IEnumerable<DiasFolga>>> GetDiasFolgaByProfissionalId(int profissionalId)
        {
            var diasFolga = await _diasFolgaService.GetDiasFolgaByProfissionalIdAsync(profissionalId);

            if (diasFolga == null)
            {
                return NotFound();
            }

            return Ok(diasFolga);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDiasFolga([FromBody] DiasFolga diasFolga)
        {
            try
            {
                await _diasFolgaService.CreateDiasFolgaAsync(diasFolga);
                return CreatedAtAction(nameof(GetDiasFolgaByProfissionalId), new { profissionalId = diasFolga.ProfissionalID }, diasFolga);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDiasFolga(int id, [FromBody] DiasFolga diasFolga)
        {
            if (id != diasFolga.ID)
            {
                return BadRequest();
            }

            try
            {
                await _diasFolgaService.UpdateDiasFolgaAsync(diasFolga);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiasFolga(int id)
        {
            try
            {
                await _diasFolgaService.DeleteDiasFolgaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
