using HireMeNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireMeNow.ViewModel
{
    public class PuestoViewModel
    {
        public IEnumerable<NivelRiesgo> NivelR { get; set; }
        public IEnumerable<Competencia> Competencias { get; set; }
        public IEnumerable<Departamento> Departamentos { get; set; }
        public IEnumerable<Estado> Estados { get; set; }
        public Puesto Puestos { get; set; }
    }
}