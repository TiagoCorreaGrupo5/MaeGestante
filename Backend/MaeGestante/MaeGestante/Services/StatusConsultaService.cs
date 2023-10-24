using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class StatusConsultaService
    {
        private readonly StatusConsultaRepository _statusConsultaRepository;

        public StatusConsultaService(StatusConsultaRepository statusConsultaRepository)
        {
            _statusConsultaRepository = statusConsultaRepository;
        }

        public async Task<IEnumerable<StatusConsulta>> GetAllStatusConsultasAsync()
        {
            return await _statusConsultaRepository.GetAllStatusConsultasAsync();
        }

        public async Task<StatusConsulta> GetStatusConsultaByIdAsync(int id)
        {
            return await _statusConsultaRepository.GetStatusConsultaByIdAsync(id);
        }
    }

}
