using HireMeNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireMeNow.ViewModel
{
    public class EmpleadosViewModel
    {
        public Empleado Empleados { get; set; }
        public IEnumerable<Puesto> Puestos { get; set; }
        public IEnumerable<Estado> Estados { get; set; }
        public IEnumerable<Departamento> Departamentos { get; set; }
    }
}