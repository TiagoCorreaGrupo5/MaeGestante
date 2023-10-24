using Dapper;
using MaeGestante.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MaeGestante.Data.Repositories
{
    public class AgendaEspecialistaRepository
    {
        private readonly string _connectionString;

        public AgendaEspecialistaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<AgendaEspecialista>> GetAgendaByProfissionalIdAsync(int profissionalId)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<AgendaEspecialista>("SELECT * FROM AgendaEspecialista WHERE ProfissionalID = @ProfissionalId", new { ProfissionalId = profissionalId });
            }
        }

        public async Task CreateAgendaEspecialistaAsync(AgendaEspecialista agendaEspecialista)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("INSERT INTO AgendaEspecialista (ProfissionalID, DiaSemana, HoraInicioManha, HoraFimManha, HoraInicioTarde, HoraFimTarde) VALUES (@ProfissionalID, @DiaSemana, @HoraInicioManha, @HoraFimManha, @HoraInicioTarde, @HoraFimTarde)", agendaEspecialista);
            }
        }

        public async Task UpdateAgendaEspecialistaAsync(AgendaEspecialista agendaEspecialista)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("UPDATE AgendaEspecialista SET ProfissionalID = @ProfissionalID, DiaSemana = @DiaSemana, HoraInicioManha = @HoraInicioManha, HoraFimManha = @HoraFimManha, HoraInicioTarde = @HoraInicioTarde, HoraFimTarde = @HoraFimTarde WHERE ID = @ID", agendaEspecialista);
            }
        }

        public async Task DeleteAgendaEspecialistaAsync(int id)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                dbConnection.Open();
                await dbConnection.ExecuteAsync("DELETE FROM AgendaEspecialista WHERE ID = @ID", new { ID = id });
            }
        }
    }
}
