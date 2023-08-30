using System.ComponentModel.DataAnnotations;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Entities;

public class Links
{
    [Key]
    public int LinksId { get; set; }

    public string Url { get; set; }

    public virtual ICollection<Carta> Cartas { get; set; } = new List<Carta>();
}