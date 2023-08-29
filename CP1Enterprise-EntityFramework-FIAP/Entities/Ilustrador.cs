﻿using CP1Enterprise_EntityFramework_FIAP.Entities;
using System.ComponentModel.DataAnnotations;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Entities;

public class Ilustrador
{
    [Key]
    public int CartaId { get; set; }

    public string Nome { get; set; }

    public virtual ICollection<Carta> Cartas { get; set; } = new List<Carta>();
}