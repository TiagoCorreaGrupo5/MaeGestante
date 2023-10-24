using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class StatusConsultaRepository
    {
        private readonly string _connectionString;

        public StatusConsultaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<StatusConsulta>> GetAllStatusConsultasAsync()
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<StatusConsulta>("SELECT * FROM StatusConsulta");
            }
        }

        public async Task<StatusConsulta> GetStatusConsultaByIdAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<StatusConsulta>("SELECT * FROM StatusConsulta WHERE ID = @Id", new { Id = id });
            }
        }
    }
}
