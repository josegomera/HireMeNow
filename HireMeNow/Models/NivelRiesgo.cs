using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Models
{
    public class NivelRiesgo
    {
        public NivelRiesgo()
        {
            Creado = DateTime.Now;
        }
        public int Id { get; set; }

        [MaxLength(6)]
        [Display(Name ="Nivel de Riesgo")]
        public string Nombre { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }

        public virtual ICollection<Puesto> Puestos { get; set; }
    }
}