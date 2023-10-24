using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MaeGestante.Data.Repositories
{
    public class CartaoGestanteRepository
    {
        private readonly string _connectionString;

        public CartaoGestanteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<CartaoGestante>> GetCartoesGestanteByGestanteIdAsync(int gestanteId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<CartaoGestante>("SELECT * FROM CartoesGestante WHERE GestanteID = @GestanteId", new { GestanteId = gestanteId });
            }
        }

        public async Task CreateCartaoGestanteAsync(CartaoGestante cartaoGestante)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("INSERT INTO CartoesGestante (GestanteID, DataEnvio, CaminhoArquivo) VALUES (@GestanteID, @DataEnvio, @CaminhoArquivo)", cartaoGestante);
            }
        }

        public async Task DeleteCartaoGestanteAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("DELETE FROM CartoesGestante WHERE ID = @ID", new { ID = id });
            }
        }

        public async Task UpdateCartaoGestanteAsync(CartaoGestante cartaoGestante)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    UPDATE CartoesGestante
                    SET DataEnvio = @DataEnvio, CaminhoArquivo = @CaminhoArquivo
                    WHERE ID = @ID";

                await connection.ExecuteAsync(query, new
                {
                    cartaoGestante.ID,
                    cartaoGestante.DataEnvio,
                    cartaoGestante.CaminhoArquivo
                });
            }
        }
    }
}
