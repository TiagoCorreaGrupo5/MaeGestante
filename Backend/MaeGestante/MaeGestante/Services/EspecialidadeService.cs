using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class EspecialidadeService
    {
        private readonly EspecialidadeRepository _especialidadeRepository;

        public EspecialidadeService(EspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        public async Task<IEnumerable<Especialidade>> GetAllEspecialidadesAsync()
        {
            return await _especialidadeRepository.GetAllEspecialidadesAsync();
        }

        public async Task<Especialidade> GetEspecialidadeByIdAsync(int id)
        {
            return await _especialidadeRepository.GetEspecialidadeByIdAsync(id);
        }
    }
}
