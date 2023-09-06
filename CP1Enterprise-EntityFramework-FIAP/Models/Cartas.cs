using System.ComponentModel.DataAnnotations;

namespace CP1Enterprise_EntityFramework_FIAP.Models
{
    public class Carta
    {
        [Key]
        public int CartaId { get; set; }

        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string FotoUrl { get; set; }
    }

}