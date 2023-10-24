using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class ConsultaService
    {
        private readonly ConsultaRepository _consultaRepository;

        public ConsultaService(ConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<IEnumerable<Consulta>> GetConsultasByGestanteIdAsync(int gestanteId)
        {
            return await _consultaRepository.GetConsultasByGestanteIdAsync(gestanteId);
        }

        public async Task<IEnumerable<Consulta>> GetConsultasByProfissionalIdAsync(int profissionalId)
        {
            return await _consultaRepository.GetConsultasByProfissionalIdAsync(profissionalId);
        }

        public async Task CreateConsultaAsync(Consulta consulta)
        {
            await _consultaRepository.CreateConsultaAsync(consulta);
        }

        public async Task UpdateConsultaAsync(Consulta consulta)
        {
            await _consultaRepository.UpdateConsultaAsync(consulta);
        }
    }
}
