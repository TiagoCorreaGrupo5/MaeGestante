using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class DiasFolgaRepository
    {
        private readonly string _connectionString;

        public DiasFolgaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<DiasFolga>> GetDiasFolgaByProfissionalIdAsync(int profissionalId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<DiasFolga>("SELECT * FROM DiasFolga WHERE ProfissionalID = @ProfissionalId", new { ProfissionalId = profissionalId });
            }
        }

        public async Task CreateDiasFolgaAsync(DiasFolga diasFolga)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("INSERT INTO DiasFolga (ProfissionalID, DataFolga, Motivo) VALUES (@ProfissionalID, @DataFolga, @Motivo)", diasFolga);
            }
        }

        public async Task DeleteDiasFolgaAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("DELETE FROM DiasFolga WHERE ID = @ID", new { ID = id });
            }
        }

        public async Task UpdateDiasFolgaAsync(DiasFolga diasFolga)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    UPDATE DiasFolga
                    SET DataFolga = @DataFolga, Motivo = @Motivo
                    WHERE ID = @ID";

                await connection.ExecuteAsync(query, new
                {
                    diasFolga.ID,
                    diasFolga.DataFolga,
                    diasFolga.Motivo
                });
            }
        }
    }
}
