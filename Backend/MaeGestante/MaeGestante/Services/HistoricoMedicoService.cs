using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class HistoricoMedicoService
    {
        private readonly HistoricoMedicoRepository _historicoMedicoRepository;

        public HistoricoMedicoService(HistoricoMedicoRepository historicoMedicoRepository)
        {
            _historicoMedicoRepository = historicoMedicoRepository;
        }

        public async Task<IEnumerable<HistoricoMedico>> GetHistoricoMedicoByGestanteIdAsync(int gestanteId)
        {
            return await _historicoMedicoRepository.GetHistoricoMedicoByGestanteIdAsync(gestanteId);
        }

        public async Task CreateHistoricoMedicoAsync(HistoricoMedico historicoMedico)
        {
            await _historicoMedicoRepository.CreateHistoricoMedicoAsync(historicoMedico);
        }

        public async Task UpdateHistoricoMedicoAsync(HistoricoMedico historicoMedico)
        {
            await _historicoMedicoRepository.UpdateHistoricoMedicoAsync(historicoMedico);
        }
    }
}
