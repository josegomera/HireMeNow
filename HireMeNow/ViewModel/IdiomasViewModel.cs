using HireMeNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireMeNow.ViewModel
{
    public class IdiomasViewModel
    {
        public IEnumerable<Estado> Estados { get; set; }
        public Idioma Idiomas { get; set; }
    }
}