using System;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Models
{
    public class Empleado
    {
        public Empleado()
        {
            Creado = DateTime.Now;
            FechaIngreso = DateTime.Now;
            EstadoId = 1;
        }
        public int Id { get; set; }

        public string Cedula { get; set; }

        [MaxLength(100)]
        public string Nombres { get; set; }

        [MaxLength(100)]
        public string Apellidos { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Puestos")]
        public int PuestosId { get; set; }
        public Puesto Puestos { get; set; }

        //[Display(Name = "Departamento")]
        //public int DepartamentosId { get; set; }
        //public Departamento Departamentos { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Salario Mensual")]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be positive")]
        public decimal SalarioMensual { get; set; }

        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        public Estado Estados { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }
        
    }
}