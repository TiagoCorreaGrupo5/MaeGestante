using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class HistoricoMedicoRepository
    {
        private readonly string _connectionString;

        public HistoricoMedicoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<HistoricoMedico>> GetHistoricoMedicoByGestanteIdAsync(int gestanteId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<HistoricoMedico>("SELECT * FROM HistoricoMedico WHERE GestanteID = @GestanteId", new { GestanteId = gestanteId });
            }
        }

        public async Task CreateHistoricoMedicoAsync(HistoricoMedico historicoMedico)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("INSERT INTO HistoricoMedico (GestanteID, ProfissionalID, DataRegistro, Descricao) VALUES (@GestanteID, @ProfissionalID, @DataRegistro, @Descricao)", historicoMedico);
            }
        }

        public async Task UpdateHistoricoMedicoAsync(HistoricoMedico historicoMedico)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("UPDATE HistoricoMedico SET GestanteID = @GestanteID, ProfissionalID = @ProfissionalID, DataRegistro = @DataRegistro, Descricao = @Descricao WHERE ID = @ID", historicoMedico);
            }
        }
    }
}
