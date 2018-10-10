using HireMeNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireMeNow.ViewModel
{
    public class HomeVireModel
    {
        public IEnumerable<Puesto> Puestos{ get; set; }
    }
}