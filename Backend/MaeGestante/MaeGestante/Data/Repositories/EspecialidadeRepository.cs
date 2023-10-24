using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class EspecialidadeRepository
    {
        private readonly string _connectionString;

        public EspecialidadeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Especialidade>> GetAllEspecialidadesAsync()
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Especialidade>("SELECT * FROM Especialidades");
            }
        }

        public async Task<Especialidade> GetEspecialidadeByIdAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Especialidade>("SELECT * FROM Especialidades WHERE ID = @Id", new { Id = id });
            }
        }
    }
}
