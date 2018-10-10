using HireMeNow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace HireMeNow.Controllers
{
    public class DashboardController : Controller
    {
        private Context db = new Context();
        // GET: Dashboard
        public ActionResult Index()
        {
            var candidatos = db.Candidatos
               .Include(c => c.Puestos)
               .Include(c => c.Capacitaciones)
               .Include(c => c.Capacitaciones.Nivel)
               .Include(c => c.Experiencias);

            return View(candidatos.ToList());
        }

    }
}
