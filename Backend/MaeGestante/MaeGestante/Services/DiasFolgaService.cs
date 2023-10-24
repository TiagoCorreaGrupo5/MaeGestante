using MaeGestante.Data.Repositories;
using MaeGestante.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaeGestante.Services
{
    public class DiasFolgaService
    {
        private readonly DiasFolgaRepository _diasFolgaRepository;

        public DiasFolgaService(DiasFolgaRepository diasFolgaRepository)
        {
            _diasFolgaRepository = diasFolgaRepository;
        }

        public async Task<IEnumerable<DiasFolga>> GetDiasFolgaByProfissionalIdAsync(int profissionalId)
        {
            return await _diasFolgaRepository.GetDiasFolgaByProfissionalIdAsync(profissionalId);
        }

        public async Task CreateDiasFolgaAsync(DiasFolga diasFolga)
        {
            await _diasFolgaRepository.CreateDiasFolgaAsync(diasFolga);
        }

        public async Task UpdateDiasFolgaAsync(DiasFolga diasFolga)
        {
            await _diasFolgaRepository.UpdateDiasFolgaAsync(diasFolga);
        }

        public async Task DeleteDiasFolgaAsync(int id)
        {
            await _diasFolgaRepository.DeleteDiasFolgaAsync(id);
        }
    }

}
