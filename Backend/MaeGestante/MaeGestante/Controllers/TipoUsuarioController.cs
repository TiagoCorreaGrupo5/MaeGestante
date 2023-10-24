using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly TipoUsuarioService _tipoUsuarioService;

        public TipoUsuarioController(TipoUsuarioService tipoUsuarioService)
        {
            _tipoUsuarioService = tipoUsuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoUsuario>>> GetAllTiposUsuario()
        {
            var tiposUsuario = await _tipoUsuarioService.GetAllTiposUsuarioAsync();
            return Ok(tiposUsuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> GetTipoUsuarioById(int id)
        {
            var tipoUsuario = await _tipoUsuarioService.GetTipoUsuarioByIdAsync(id);

            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return Ok(tipoUsuario);
        }
    }
}
