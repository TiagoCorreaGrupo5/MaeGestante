using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class ReceitaService
    {
        private readonly ReceitaRepository _receitaRepository;

        public ReceitaService(ReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        public async Task<IEnumerable<Receita>> GetReceitasByGestanteIdAsync(int gestanteId)
        {
            return await _receitaRepository.GetReceitasByGestanteIdAsync(gestanteId);
        }

        public async Task CreateReceitaAsync(Receita receita)
        {
            await _receitaRepository.CreateReceitaAsync(receita);
        }

        public async Task UpdateReceitaAsync(Receita receita)
        {
            await _receitaRepository.UpdateReceitaAsync(receita);
        }

        public async Task<Receita> GetReceitaByIdAsync(int id)
        {
            return await _receitaRepository.GetReceitaByIdAsync(id);
        }
    }
}
