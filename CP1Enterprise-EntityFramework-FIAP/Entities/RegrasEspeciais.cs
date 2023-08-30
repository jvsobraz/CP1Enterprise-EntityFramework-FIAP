using System.ComponentModel.DataAnnotations;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Entities;

public class RegrasEspeciais
{
    [Key]
    public int RegrasEspeciaisId { get; set; }

    public string Descricao { get; set; }
    public DateTime Data { get; set; }

    public virtual ICollection<Carta> Cartas { get; set; } = new List<Carta>();
}