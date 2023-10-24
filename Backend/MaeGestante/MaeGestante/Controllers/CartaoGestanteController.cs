using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoGestanteController : ControllerBase
    {
        private readonly CartaoGestanteService _cartaoGestanteService;

        public CartaoGestanteController(CartaoGestanteService cartaoGestanteService)
        {
            _cartaoGestanteService = cartaoGestanteService;
        }

        [HttpGet("gestante/{gestanteId}")]
        public async Task<ActionResult<IEnumerable<CartaoGestante>>> GetCartoesGestanteByGestanteId(int gestanteId)
        {
            var cartoesGestante = await _cartaoGestanteService.GetCartoesGestanteByGestanteIdAsync(gestanteId);

            if (cartoesGestante == null)
            {
                return NotFound();
            }

            return Ok(cartoesGestante);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCartaoGestante([FromBody] CartaoGestante cartaoGestante)
        {
            try
            {
                await _cartaoGestanteService.CreateCartaoGestanteAsync(cartaoGestante);
                return CreatedAtAction(nameof(GetCartoesGestanteByGestanteId), new { gestanteId = cartaoGestante.GestanteID }, cartaoGestante);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCartaoGestante(int id, [FromBody] CartaoGestante cartaoGestante)
        {
            if (id != cartaoGestante.ID)
            {
                return BadRequest();
            }

            try
            {
                await _cartaoGestanteService.UpdateCartaoGestanteAsync(cartaoGestante);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCartaoGestante(int id)
        {
            try
            {
                await _cartaoGestanteService.DeleteCartaoGestanteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

