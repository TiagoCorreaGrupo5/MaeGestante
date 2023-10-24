using MaeGestante.Data.Repositories;
using MaeGestante.Models;

namespace MaeGestante.Services
{
    public class CartaoGestanteService
    {
        private readonly CartaoGestanteRepository _cartaoGestanteRepository;

        public CartaoGestanteService(CartaoGestanteRepository cartaoGestanteRepository)
        {
            _cartaoGestanteRepository = cartaoGestanteRepository;
        }

        public async Task<IEnumerable<CartaoGestante>> GetCartoesGestanteByGestanteIdAsync(int gestanteId)
        {
            return await _cartaoGestanteRepository.GetCartoesGestanteByGestanteIdAsync(gestanteId);
        }

        public async Task CreateCartaoGestanteAsync(CartaoGestante cartaoGestante)
        {
            await _cartaoGestanteRepository.CreateCartaoGestanteAsync(cartaoGestante);
        }

        public async Task UpdateCartaoGestanteAsync(CartaoGestante cartaoGestante)
        {
            await _cartaoGestanteRepository.UpdateCartaoGestanteAsync(cartaoGestante);
        }

        public async Task DeleteCartaoGestanteAsync(int id)
        {
            await _cartaoGestanteRepository.DeleteCartaoGestanteAsync(id);
        }
    }

}
