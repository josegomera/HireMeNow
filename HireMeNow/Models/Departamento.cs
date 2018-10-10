using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Models
{
    public class Departamento
    {
        public Departamento()
        {
            Creado = DateTime.Now;
        }
        public int Id { get; set; }

        [MaxLength(30)]
        [Display(Name ="Departamento")]
        public string Departamentos { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }

        public virtual ICollection<Puesto> Puestos { get; set; }

    }
}