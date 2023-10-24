namespace MaeGestante.Models
{
    public class Receita
    {
        public int ID { get; set; }
        public int GestanteID { get; set; }
        public int ProfissionalID { get; set; }
        public string Medicamentos { get; set; }
        public DateTime DataPrescricao { get; set; }
    }

}
