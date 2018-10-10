using HireMeNow.DAL;
using HireMeNow.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireMeNow.Controllers
{
    public class HomeController : Controller
    {
        private Context db = new Context();
        public ActionResult Index()
        {
            var puestos = db.Puestos.Include(p => p.Competencias);

            return View(puestos.ToList());
        }


        // GET: Candidatos/Create
        public ActionResult Create()
        {
            var viewModel = new CandidatosViewModel()
            {
                Puestos = db.Puestos.ToList(),
                Niveles = db.Niveles.ToList(),
                Capacitaciones = db.Capacitaciones.ToList(),
                Experiencias = db.ExpLaboral.ToList()
            };
            return View(viewModel);
        }

        //POST: Candidatos/Create
        [HttpPost]
        public ActionResult Create(CandidatosViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                db.Candidatos.Add(viewModel.Candidatos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", viewModel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}