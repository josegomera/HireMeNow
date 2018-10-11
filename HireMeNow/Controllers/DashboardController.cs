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
            var Empleado = db.Empleados
                .Include(c => c.Puestos)
                .Include(c => c.Estados);

            return View(Empleado.ToList());
        }

    }
}
