using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUserById(int id)
        {
            var usuario = await _usuarioService.GetUserByIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] Usuario usuario)
        {
            try
            {
                await _usuarioService.CreateUserAsync(usuario);
                return CreatedAtAction(nameof(GetUserById), new { id = usuario.ID }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.ID)
            {
                return BadRequest();
            }

            try
            {
                await _usuarioService.UpdateUserAsync(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginRequestModel request)
        {
            var user = await _usuarioService.LoginAsync(request.Email, request.Senha);

            if (user == null)
            {
                return Unauthorized();
            }

            // Gere um token JWT e retorne-o como resposta

            return Ok(new { Token = "seu_token_jwt_aqui" });
        }
    }
}
