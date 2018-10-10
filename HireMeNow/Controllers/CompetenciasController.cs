using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HireMeNow.DAL;
using HireMeNow.Models;
using HireMeNow.ViewModel;

namespace HireMeNow.Controllers
{
    public class CompetenciasController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            var competencias = db.Competencias
                .Include(c => c.Idiomas)
                .Include(c => c.Estado);

            return View(competencias.ToList());
        }

        public ActionResult New()
        {
            var ViewModel = new NewCompetenciasViewModel
            {
                Idiomas = db.Idiomas.ToList(),
                Estados = db.Estados.ToList()
            };

            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Create(NewCompetenciasViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                db.Competencias.Add(viewModel.Competencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("New", viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new NewCompetenciasViewModel
            {
                Competencias = db.Competencias.Find(id),
                Idiomas = db.Idiomas.ToList(),
                Estados = db.Estados.ToList()
            };

            if (viewModel.Competencias == null)
            {
                return HttpNotFound();
            }

            return View("Edit", viewModel);
        }


        [HttpPost]
        public ActionResult Edit(NewCompetenciasViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewModel.Competencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
