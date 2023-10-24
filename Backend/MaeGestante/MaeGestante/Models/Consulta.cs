namespace MaeGestante.Models
{
    public class Consulta
    {
        public int ID { get; set; }
        public int GestanteID { get; set; }
        public int ProfissionalID { get; set; }
        public DateTime DataHoraConsulta { get; set; }
        public int StatusConsultaID { get; set; }
    }

}
