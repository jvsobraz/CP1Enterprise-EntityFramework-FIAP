using CP1Enterprise_EntityFramework_FIAP.Models;
using System;
namespace CP1Enterprise_EntityFramework_FIAP.Models
{
    public class RegrasEspeciais
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }


        public virtual Carta Carta { get; set; }
    }
}
