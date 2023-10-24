using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class ReceitaRepository
    {
        private readonly string _connectionString;

        public ReceitaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Receita>> GetReceitasByGestanteIdAsync(int gestanteId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Receita>("SELECT * FROM Receitas WHERE GestanteID = @GestanteId", new { GestanteId = gestanteId });
            }
        }

        public async Task<Receita> GetReceitaByIdAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Receita>("SELECT * FROM Receitas WHERE ID = @Id", new { Id = id });
            }
        }

        public async Task CreateReceitaAsync(Receita receita)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("INSERT INTO Receitas (GestanteID, ProfissionalID, Medicamentos, DataPrescricao) VALUES (@GestanteID, @ProfissionalID, @Medicamentos, @DataPrescricao)", receita);
            }
        }

        public async Task UpdateReceitaAsync(Receita receita)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("UPDATE Receitas SET GestanteID = @GestanteID, ProfissionalID = @ProfissionalID, Medicamentos = @Medicamentos, DataPrescricao = @DataPrescricao WHERE ID = @ID", receita);
            }
        }
    }
}
