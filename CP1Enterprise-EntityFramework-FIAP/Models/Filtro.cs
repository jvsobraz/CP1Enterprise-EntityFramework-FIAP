using CP1Enterprise_EntityFramework_FIAP.Models;
using System;
namespace CP1Enterprise_EntityFramework_FIAP.Models
{
    public class Filtro
    {
        public int Id { get; set; }
        public string nome { get; set; }


        public virtual Carta Carta { get; set; }
    }
}
