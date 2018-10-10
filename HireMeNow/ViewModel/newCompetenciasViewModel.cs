using HireMeNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireMeNow.ViewModel
{
    public class NewCompetenciasViewModel
    {
        public IEnumerable<Idioma> Idiomas { get; set; }
        public IEnumerable<Estado> Estados { get; set; }
        public Competencia Competencias { get; set; }
    }
}