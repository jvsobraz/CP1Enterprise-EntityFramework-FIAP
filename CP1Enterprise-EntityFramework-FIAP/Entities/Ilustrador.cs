using System.ComponentModel.DataAnnotations;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Entities;

public class Ilustrador
{
    [Key]
    public int IlustradorId { get; set; }

    public string Nome { get; set; }

    public virtual ICollection<Carta> Cartas { get; set; } = new List<Carta>();
}