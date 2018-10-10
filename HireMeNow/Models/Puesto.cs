using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Models
{
    public class Puesto
    {
        public Puesto()
        {
            Creado = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name ="Nombre del Puesto")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name ="Nivel de Riesgo")]
        public int  NivelRiesgosId { get; set; }
        public NivelRiesgo NivelRiesgos { get; set; }
        
        [Required]
        [Display(Name ="Competencia")]
        public int  CompetenciasId { get; set; }
        public Competencia Competencias { get; set; }

        [Required]
        [Display(Name ="Departamento")]
        public int  DepartamentosId { get; set; }
        public Departamento Departamentos { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name ="Salario Minimo")]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be positive")]
        public decimal SalarioMin { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name ="Salario Maximo")]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be positive")]
        public decimal SalarioMax { get; set; }
  
        [Required]
        [Display(Name ="Estado")]
        public int  EstadoId { get; set; }
        public Estado Estados { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }

        public virtual ICollection<Candidato> Candidatos { get; set; }

    }
}