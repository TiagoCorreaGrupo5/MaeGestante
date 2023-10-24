using MaeGestante.Models;
using MaeGestante.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaeGestante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusConsultaController : ControllerBase
    {
        private readonly StatusConsultaService _statusConsultaService;

        public StatusConsultaController(StatusConsultaService statusConsultaService)
        {
            _statusConsultaService = statusConsultaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusConsulta>>> GetAllStatusConsultas()
        {
            var statusConsultas = await _statusConsultaService.GetAllStatusConsultasAsync();
            return Ok(statusConsultas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusConsulta>> GetStatusConsultaById(int id)
        {
            var statusConsulta = await _statusConsultaService.GetStatusConsultaByIdAsync(id);

            if (statusConsulta == null)
            {
                return NotFound();
            }

            return Ok(statusConsulta);
        }
    }
}
