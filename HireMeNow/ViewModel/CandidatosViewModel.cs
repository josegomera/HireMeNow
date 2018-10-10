using HireMeNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireMeNow.ViewModel
{
    public class CandidatosViewModel
    {
        public Candidato Candidatos { get; set; }

        public IEnumerable<Puesto> Puestos { get; set; }
        public IEnumerable<Nivel> Niveles { get; set; }
        public IEnumerable<Capacitacion> Capacitaciones { get; set; }
        public IEnumerable<ExperienciaLaboral> Experiencias { get; set; }

    }
}