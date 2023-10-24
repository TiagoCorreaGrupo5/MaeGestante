using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class TipoUsuarioService
    {
        private readonly TipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioService(TipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        public async Task<IEnumerable<TipoUsuario>> GetAllTiposUsuarioAsync()
        {
            return await _tipoUsuarioRepository.GetAllTiposUsuarioAsync();
        }

        public async Task<TipoUsuario> GetTipoUsuarioByIdAsync(int id)
        {
            return await _tipoUsuarioRepository.GetTipoUsuarioByIdAsync(id);
        }
    }

}
