using MaeGestante.Data.Repositories;
using MaeGestante.Models;
using System.Security.Cryptography;
using System.Text;

namespace MaeGestante.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CreateUserAsync(Usuario usuario)
        {
            // Converter a senha para MD5 antes de salvar no banco de dados
            usuario.Senha = CalculateMD5Hash(usuario.Senha);
            await _usuarioRepository.CreateUsuarioAsync(usuario);
        }

        public async Task UpdateUserAsync(Usuario usuario)
        {
            // Converter a senha para MD5 antes de atualizar no banco de dados
            usuario.Senha = CalculateMD5Hash(usuario.Senha);
            await _usuarioRepository.UpdateUsuarioAsync(usuario);
        }

        public async Task<Usuario> GetUserByIdAsync(int id)
        {
            return await _usuarioRepository.GetUsuarioByIdAsync(id);
        }

        public async Task<Usuario> LoginAsync(string email, string senha)
        {
            // Converter a senha fornecida para MD5
            string senhaMD5 = CalculateMD5Hash(senha);

            return await _usuarioRepository.LoginAsync(email, senhaMD5);
        }

        // Função para calcular o hash MD5 de uma string
        private string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
