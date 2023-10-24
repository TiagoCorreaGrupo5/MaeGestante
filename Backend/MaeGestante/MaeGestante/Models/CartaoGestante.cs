namespace MaeGestante.Models
{
    public class CartaoGestante
    {
        public int ID { get; set; }
        public int GestanteID { get; set; }
        public DateTime DataEnvio { get; set; }
        public string CaminhoArquivo { get; set; } // Caminho do arquivo de imagem do cartão
    }

}
