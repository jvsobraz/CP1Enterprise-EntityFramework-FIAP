using CP1Enterprise_EntityFramework_FIAP.Entities;
using System.ComponentModel.DataAnnotations;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Entities;

public class Colecao
{
    [Key]
    public int ColecaoId { get; set; }

    public string Nome { get; set; }
    public DateTime Ano { get; set; }
    public string LogoUrl { get; set; }

    public virtual ICollection<Carta> Cartas { get; set; } = new List<Carta>();
}