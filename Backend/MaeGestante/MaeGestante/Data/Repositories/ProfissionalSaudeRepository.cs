using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class ProfissionalSaudeRepository
    {
        private readonly string _connectionString;

        public ProfissionalSaudeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ProfissionalSaude>> GetProfissionaisSaudeByEspecialidadeAsync(int especialidadeId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<ProfissionalSaude>("SELECT * FROM ProfissionaisSaude WHERE EspecialidadeID = @EspecialidadeId", new { EspecialidadeId = especialidadeId });
            }
        }

        public async Task<ProfissionalSaude> GetProfissionalSaudeByIdAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<ProfissionalSaude>("SELECT * FROM ProfissionaisSaude WHERE ID = @Id", new { Id = id });
            }
        }

        public async Task CreateProfissionalSaudeAsync(ProfissionalSaude profissionalSaude)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("INSERT INTO ProfissionaisSaude (Nome, Contato, UsuarioID, EspecialidadeID) VALUES (@Nome, @Contato, @UsuarioID, @EspecialidadeID)", profissionalSaude);
            }
        }

        public async Task UpdateProfissionalSaudeAsync(ProfissionalSaude profissionalSaude)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("UPDATE ProfissionaisSaude SET Nome = @Nome, Contato = @Contato, UsuarioID = @UsuarioID, EspecialidadeID = @EspecialidadeID WHERE ID = @ID", profissionalSaude);
            }
        }

        public async Task DeleteProfissionalSaudeAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("DELETE FROM ProfissionaisSaude WHERE ID = @ID", new { ID = id });
            }
        }
    }
}
