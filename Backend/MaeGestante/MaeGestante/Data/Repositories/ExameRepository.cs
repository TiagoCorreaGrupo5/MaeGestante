using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class ExameRepository
    {
        private readonly string _connectionString;

        public ExameRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Exame>> GetExamesByGestanteIdAsync(int gestanteId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Exame>("SELECT * FROM Exames WHERE GestanteID = @GestanteId", new { GestanteId = gestanteId });
            }
        }

        public async Task CreateExameAsync(Exame exame)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("INSERT INTO Exames (GestanteID, ProfissionalID, TipoExame, DataSolicitacao, Resultado) VALUES (@GestanteID, @ProfissionalID, @TipoExame, @DataSolicitacao, @Resultado)", exame);
            }
        }

        public async Task UpdateExameAsync(Exame exame)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("UPDATE Exames SET GestanteID = @GestanteID, ProfissionalID = @ProfissionalID, TipoExame = @TipoExame, DataSolicitacao = @DataSolicitacao, Resultado = @Resultado WHERE ID = @ID", exame);
            }
        }

        public async Task<Exame> GetExameByIdAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Exame>("SELECT * FROM Exames WHERE ID = @Id", new { Id = id });
            }
        }
    }
}
