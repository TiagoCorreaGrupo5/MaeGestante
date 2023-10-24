namespace MaeGestante.Models
{
    public class ProfissionalSaude
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public int UsuarioID { get; set; } // Chave única para associar ao usuário
        public int EspecialidadeID { get; set; } // Referência à especialidade
    }
}
