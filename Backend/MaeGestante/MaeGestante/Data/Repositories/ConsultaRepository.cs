using MaeGestante.Models;

namespace MaeGestante.Data.Repositories
{
    public class ConsultaRepository
    {
        private readonly string _connectionString;

        public ConsultaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Consulta>> GetConsultasByGestanteIdAsync(int gestanteId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Consulta>("SELECT * FROM Consultas WHERE GestanteID = @GestanteId", new { GestanteId = gestanteId });
            }
        }

        public async Task<IEnumerable<Consulta>> GetConsultasByProfissionalIdAsync(int profissionalId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<Consulta>("SELECT * FROM Consultas WHERE ProfissionalID = @ProfissionalId", new { ProfissionalId = profissionalId });
            }
        }

        public async Task CreateConsultaAsync(Consulta consulta)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("INSERT INTO Consultas (GestanteID, ProfissionalID, DataHoraConsulta, StatusConsultaID) VALUES (@GestanteID, @ProfissionalID, @DataHoraConsulta, @StatusConsultaID)", consulta);
            }
        }

        public async Task UpdateConsultaAsync(Consulta consulta)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("UPDATE Consultas SET GestanteID = @GestanteID, ProfissionalID = @ProfissionalID, DataHoraConsulta = @DataHoraConsulta, StatusConsultaID = @StatusConsultaID WHERE ID = @ID", consulta);
            }
        }
    }
}
