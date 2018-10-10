using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireMeNow.Models
{
    public class Estado
    {
        public Estado()
        {
            Creado = DateTime.Now;
        }
        public int Id { get; set; }

        [MaxLength(10)]
        [Display(Name="Estado")]
        public string Estados { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }

        public ICollection<Competencia> Competencias { get; set; }
        public ICollection<Idioma> Idiomas { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}