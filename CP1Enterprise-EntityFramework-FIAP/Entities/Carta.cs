using System.ComponentModel.DataAnnotations;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Entities;

public class Carta
{
    [Key]
    public int CartaId { get; set; }

    public string Nome { get; set; }
    public string Tipo { get; set; }
    public string Descricao { get; set; }
    public string FotoUrl { get; set; }

    public virtual ICollection<Colecao> Colecoes { get; set; } = new List<Colecao>();
    public virtual ICollection<Idioma> Idiomas { get; set; } = new List<Idioma>();
    public virtual ICollection<Ilustrador> Ilustradores { get; set; } = new List<Ilustrador>();
    public virtual ICollection<Links> Links { get; set; } = new List<Links>();
    public virtual ICollection<RegrasEspeciais> RegrasEspeciais { get; set; } = new List<RegrasEspeciais>();
}