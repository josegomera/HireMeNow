using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Models
{
    public class Competencia
    {
        public Competencia()
        {
            Creado = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name ="Competencias")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name ="Idiomas")]
        public int IdiomasId { get; set; }

        public Idioma Idiomas { get; set; }
        
        [Required]
        [Display(Name = "Estados")]
        public int EstadoId { get; set; }

        public Estado Estado { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }


        public virtual ICollection<Puesto> Puestos { get; set; }
    }
}