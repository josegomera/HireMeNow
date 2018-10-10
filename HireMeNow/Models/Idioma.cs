using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Models
{
    public class Idioma
    {
        public Idioma()
        {
            Creado = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [DisplayName("Idioma")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        public Estado Estado { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }


        public virtual ICollection<Competencia> Competencias { get; set; }

    }
}