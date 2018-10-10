using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Models
{
    public class Nivel
    {
        public Nivel()
        {
            Creado = DateTime.Now;
        }
        public int Id { get; set; }

        [MaxLength(25)]
        [Display(Name ="Nivel Educativo")]
        public string Nombre { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }

        public virtual ICollection<Capacitacion> Capacitaciones { get; set; }
    }
}