namespace MaeGestante.Models
{
    public class Exame
    {
        public int ID { get; set; }
        public int GestanteID { get; set; }
        public int ProfissionalID { get; set; }
        public string TipoExame { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Resultado { get; set; } // Caminho de arquivo ou descrição do resultado
    }

}
