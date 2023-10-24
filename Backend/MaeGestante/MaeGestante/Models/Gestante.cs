namespace MaeGestante.Models
{
    public class Gestante
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataPrevistaParto { get; set; }
        public int UsuarioID { get; set; } // Chave única para associar ao usuário
    }
}
