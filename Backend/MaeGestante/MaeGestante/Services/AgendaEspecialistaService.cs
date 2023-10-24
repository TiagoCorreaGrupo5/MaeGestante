using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class AgendaEspecialistaService
    {
        private readonly AgendaEspecialistaRepository _agendaEspecialistaRepository;

        public AgendaEspecialistaService(AgendaEspecialistaRepository agendaEspecialistaRepository)
        {
            _agendaEspecialistaRepository = agendaEspecialistaRepository;
        }

        public async Task<IEnumerable<AgendaEspecialista>> GetAgendaByProfissionalIdAsync(int profissionalId)
        {
            return await _agendaEspecialistaRepository.GetAgendaByProfissionalIdAsync(profissionalId);
        }

        public async Task CreateAgendaEspecialistaAsync(AgendaEspecialista agendaEspecialista)
        {
            await _agendaEspecialistaRepository.CreateAgendaEspecialistaAsync(agendaEspecialista);
        }

        public async Task UpdateAgendaEspecialistaAsync(AgendaEspecialista agendaEspecialista)
        {
            await _agendaEspecialistaRepository.UpdateAgendaEspecialistaAsync(agendaEspecialista);
        }

        public async Task DeleteAgendaEspecialistaAsync(int id)
        {
            await _agendaEspecialistaRepository.DeleteAgendaEspecialistaAsync(id);
        }
    }

}
