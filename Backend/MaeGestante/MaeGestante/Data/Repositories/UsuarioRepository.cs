using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Usuario>("SELECT * FROM Usuarios");
            }
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuarios WHERE ID = @Id", new { Id = id });
            }
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("INSERT INTO Usuarios (Nome, Sobrenome, Email, Senha, TipoUsuarioID) VALUES (@Nome, @Sobrenome, @Email, @Senha, @TipoUsuarioID)", usuario);
            }
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("UPDATE Usuarios SET Nome = @Nome, Sobrenome = @Sobrenome, Email = @Email, Senha = @Senha, TipoUsuarioID = @TipoUsuarioID WHERE ID = @ID", usuario);
            }
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("DELETE FROM Usuarios WHERE ID = @ID", new { ID = id });
            }
        }

        public async Task<Usuario> LoginAsync(string email, string senha)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuarios WHERE Email = @Email AND Senha = @Senha", new { Email = email, Senha = senha });
            }
        }
    }
}
