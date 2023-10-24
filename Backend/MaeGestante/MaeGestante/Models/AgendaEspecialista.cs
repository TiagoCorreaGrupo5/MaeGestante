namespace MaeGestante.Models
{
    public class AgendaEspecialista
    {
        public int ID { get; set; }
        public int ProfissionalID { get; set; }
        public int DiaSemana { get; set; }
        public TimeSpan HoraInicioManha { get; set; }
        public TimeSpan HoraFimManha { get; set; }
        public TimeSpan HoraInicioTarde { get; set; }
        public TimeSpan HoraFimTarde { get; set; }
    }
}
