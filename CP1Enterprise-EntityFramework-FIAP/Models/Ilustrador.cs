using CP1Enterprise_EntityFramework_FIAP.Models;
using System;
namespace CP1.Models
{
    public class Ilustrador
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual Carta Carta { get; set; }

    }
}
