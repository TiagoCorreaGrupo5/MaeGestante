using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class ExameService
    {
        private readonly ExameRepository _exameRepository;

        public ExameService(ExameRepository exameRepository)
        {
            _exameRepository = exameRepository;
        }

        public async Task<IEnumerable<Exame>> GetExamesByGestanteIdAsync(int gestanteId)
        {
            return await _exameRepository.GetExamesByGestanteIdAsync(gestanteId);
        }

        public async Task CreateExameAsync(Exame exame)
        {
            await _exameRepository.CreateExameAsync(exame);
        }

        public async Task<Exame> GetExameByIdAsync(int id)
        {
            return await _exameRepository.GetExameByIdAsync(id);
        }

        public async Task UpdateExameAsync(Exame exame)
        {
            await _exameRepository.UpdateExameAsync(exame);
        }
    }
}
