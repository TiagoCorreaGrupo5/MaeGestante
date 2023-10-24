using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class TipoUsuarioRepository
    {
        private readonly string _connectionString;

        public TipoUsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<TipoUsuario>> GetAllTiposUsuarioAsync()
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<TipoUsuario>("SELECT * FROM TiposUsuario");
            }
        }

        public async Task<TipoUsuario> GetTipoUsuarioByIdAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<TipoUsuario>("SELECT * FROM TiposUsuario WHERE ID = @Id", new { Id = id });
            }
        }
    }
}
