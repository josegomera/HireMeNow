using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Models
{
    public class Capacitacion
    {
        public Capacitacion()
        {
            Creado = DateTime.Now;
        }
        
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Nombre Capacitacion")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name ="Nivel Educativo")]
        public int NivelId { get; set; }
        public Nivel Nivel { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaDesde { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Termino")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaHasta { get; set; }

        [Required]
        [MaxLength(50)]
        public string Institucion { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }

      
        public virtual ICollection<Candidato> Candidatos { get; set; }
    }
}