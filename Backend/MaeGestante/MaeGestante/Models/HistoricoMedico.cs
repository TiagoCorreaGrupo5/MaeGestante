namespace MaeGestante.Models
{
    public class HistoricoMedico
    {
        public int ID { get; set; }
        public int GestanteID { get; set; }
        public int ProfissionalID { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Descricao { get; set; }
    }

}
