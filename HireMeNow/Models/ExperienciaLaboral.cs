using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Models
{
    public class ExperienciaLaboral
    {
        public ExperienciaLaboral()
        {
            Creado = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Empresa { get; set; }

        [Required]
        [MaxLength(70)]
        [Display(Name ="Puesto Ocupado")]
        public string PuestoOcupado { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaDesde { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Retiro")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaHasta { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be positive")]
        public decimal  Salario { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }

        public virtual ICollection<Candidato> Candidatos { get; set; }
    }
}