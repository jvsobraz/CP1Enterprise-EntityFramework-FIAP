using CP1Enterprise_EntityFramework_FIAP.Models;
using System;
namespace CP1Enterprise_EntityFramework_FIAP.Models
{
    public class Links
    {
        public int Id;
        public string Url;

        public virtual Carta Carta { get; set; }
    }
}
