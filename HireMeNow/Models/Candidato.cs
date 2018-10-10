using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow.Models
{
    public class Candidato
    {
        public Candidato()
        {
            Creado = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(11)]
        [RegularExpression(@"^\d{3}\d{7}\d{1}$", ErrorMessage = "Cedula Incorrecta")]
        public string Cedula { get; set; }
    

        [Required]
        [MaxLength(100)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Puestos")]
        public int PuestosId { get; set; }
        public Puesto Puestos { get; set; }


        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Expectativa Salarial")]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be positive")]
        public decimal Salario { get; set; }


        [Required]
        [Display(Name = "Capacitaciones")]
        public int CapacitacionesId { get; set; }
        public Capacitacion Capacitaciones { get; set; }

        [Required]
        [Display(Name = "Experiencias")]
        public int ExperienciasId { get; set; }
        public ExperienciaLaboral Experiencias { get; set; }

        [MaxLength(60)]
        [Display(Name = "Recomendado")]
        public string RecomendadoPor { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Creado { get; set; }

    }
}


public class Validator
{
    public Validator()
    { }

    public static bool validaCedula(string pCedula)
    { 
        int vnTotal = 0;
        string vcCedula = pCedula.Replace("-", "");
        int pLongCed = vcCedula.Trim().Length;
        int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

        if (pLongCed < 11 || pLongCed > 11)
            return false;

        for (int vDig = 1; vDig <= pLongCed; vDig++)
        {
            int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
            if (vCalculo < 10)
                vnTotal += vCalculo;
            else
                vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
        }

        if (vnTotal % 10 == 0)
            return true;
        else
            return false;
    }

}