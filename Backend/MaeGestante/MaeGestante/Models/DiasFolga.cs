namespace MaeGestante.Models
{
    public class DiasFolga
    {
        public int ID { get; set; }
        public int ProfissionalID { get; set; }
        public DateTime DataFolga { get; set; }
        public string Motivo { get; set; } // Motivo da folga (opcional)
    }

}
