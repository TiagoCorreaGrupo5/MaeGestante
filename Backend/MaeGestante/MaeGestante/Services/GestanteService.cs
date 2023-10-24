using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class GestanteService
    {
        private readonly GestanteRepository _gestanteRepository;

        public GestanteService(GestanteRepository gestanteRepository)
        {
            _gestanteRepository = gestanteRepository;
        }

        public async Task<IEnumerable<Gestante>> GetGestantesAsync()
        {
            return await _gestanteRepository.GetAllGestantesAsync();
        }

        public async Task<Gestante> GetGestanteByIdAsync(int id)
        {
            return await _gestanteRepository.GetGestanteByIdAsync(id);
        }

        public async Task CreateGestanteAsync(Gestante gestante)
        {
            await _gestanteRepository.CreateGestanteAsync(gestante);
        }

        public async Task UpdateGestanteAsync(Gestante gestante)
        {
            await _gestanteRepository.UpdateGestanteAsync(gestante);
        }

        public async Task<IEnumerable<Gestante>> GetAllGestantesAsync()
        {
            return await _gestanteRepository.GetAllGestantesAsync();
        }

        public async Task DeleteGestanteAsync(int id)
        {
            await _gestanteRepository.DeleteGestanteAsync(id);
        }
    }
}
