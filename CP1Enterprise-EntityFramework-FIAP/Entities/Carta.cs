using System.ComponentModel.DataAnnotations;

namespace HookingHotels.Web.Entities;

public class Hospede
{
    [Key]
    public int HospedeId { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }
    public string Telefone { get; set; }

    public string? Endereco { get; set; }

    public bool EstaAtivo { get; set; } = true;

    // Relacionamento com Reserva
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}