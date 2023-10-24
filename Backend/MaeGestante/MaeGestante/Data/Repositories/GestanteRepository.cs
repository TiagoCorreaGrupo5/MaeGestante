using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class GestanteRepository
    {
        private readonly string _connectionString;

        public GestanteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Gestante>> GetAllGestantesAsync()
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Gestante>("SELECT * FROM Gestantes");
            }
        }

        public async Task<Gestante> GetGestanteByIdAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Gestante>("SELECT * FROM Gestantes WHERE ID = @Id", new { Id = id });
            }
        }

        public async Task CreateGestanteAsync(Gestante gestante)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("INSERT INTO Gestantes (Nome, DataPrevistaParto, UsuarioID) VALUES (@Nome, @DataPrevistaParto, @UsuarioID)", gestante);
            }
        }

        public async Task UpdateGestanteAsync(Gestante gestante)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("UPDATE Gestantes SET Nome = @Nome, DataPrevistaParto = @DataPrevistaParto, UsuarioID = @UsuarioID WHERE ID = @ID", gestante);
            }
        }

        public async Task DeleteGestanteAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("DELETE FROM Gestantes WHERE ID = @ID", new { ID = id });
            }
        }
    }
}
