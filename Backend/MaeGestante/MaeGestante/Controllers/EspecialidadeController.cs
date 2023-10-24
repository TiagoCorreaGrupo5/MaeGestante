using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly EspecialidadeService _especialidadeService;

        public EspecialidadeController(EspecialidadeService especialidadeService)
        {
            _especialidadeService = especialidadeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especialidade>>> GetAllEspecialidades()
        {
            var especialidades = await _especialidadeService.GetAllEspecialidadesAsync();

            if (especialidades == null)
            {
                return NotFound();
            }

            return Ok(especialidades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidade>> GetEspecialidadeById(int id)
        {
            var especialidade = await _especialidadeService.GetEspecialidadeByIdAsync(id);

            if (especialidade == null)
            {
                return NotFound();
            }

            return Ok(especialidade);
        }
    }
}
