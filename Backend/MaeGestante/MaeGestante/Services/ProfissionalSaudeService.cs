using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class ProfissionalSaudeService
    {
        private readonly ProfissionalSaudeRepository _profissionalSaudeRepository;

        public ProfissionalSaudeService(ProfissionalSaudeRepository profissionalSaudeRepository)
        {
            _profissionalSaudeRepository = profissionalSaudeRepository;
        }

        public async Task<IEnumerable<ProfissionalSaude>> GetProfissionaisSaudeByEspecialidadeAsync(int especialidadeId)
        {
            return await _profissionalSaudeRepository.GetProfissionaisSaudeByEspecialidadeAsync(especialidadeId);
        }

        public async Task<ProfissionalSaude> GetProfissionalSaudeByIdAsync(int id)
        {
            return await _profissionalSaudeRepository.GetProfissionalSaudeByIdAsync(id);
        }
        public async Task CreateProfissionalSaudeAsync(ProfissionalSaude profissionalSaude)
        {
            await _profissionalSaudeRepository.CreateProfissionalSaudeAsync(profissionalSaude);
        }

        public async Task UpdateProfissionalSaudeAsync(ProfissionalSaude profissionalSaude)
        {
            await _profissionalSaudeRepository.UpdateProfissionalSaudeAsync(profissionalSaude);
        }

        public async Task DeleteProfissionalSaudeAsync(int id)
        {
            await _profissionalSaudeRepository.DeleteProfissionalSaudeAsync(id);
        }
    }
}
