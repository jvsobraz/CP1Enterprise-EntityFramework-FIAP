using CP1Enterprise_EntityFramework_FIAP.Models;
using CP1Enterprise_EntityFramework_FIAP.Edits;
using System;
using System.ComponentModel.DataAnnotations;
using CP1Enterprise_EntityFramework_FIAP.Models;

namespace CP1Enterprise_EntityFramework_FIAP.Models
{
    public class Carta
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Url Foto")]
        public string FotoUrl { get; set; }

        public virtual Links Links { get; set; }
        public virtual Ilustrador Ilustrador { get; set; }
        public virtual Colecao Colecao { get; set; }
        public virtual ICollection<Idioma> Idiomas { get; set; }
        public virtual ICollection<RegrasEspeciais> RegrasEspeciais { get; set; }
        public virtual ICollection<Filtro> Filtros { get; set; }

        public Carta(Edit edit)
        {
            Tipo = edit.Tipo;
            Descricao = edit.Descricao;
            Links.Url = edit.Url;
        }
    }
}
