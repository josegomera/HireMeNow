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
    public class CandidatosController : Controller
    {
        private Context db = new Context();


        // GET: Candidatos
        public ActionResult Index()
        {
            var candidatos = db.Candidatos
                .Include(c => c.Puestos)
                .Include(c => c.Capacitaciones)
                .Include(c => c.Capacitaciones.Nivel)
                .Include(c => c.Experiencias);

            return View(candidatos.ToList());
        }

        // GET: Candidatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new CandidatosViewModel()
            {
                Candidatos = db.Candidatos.Find(id),
                Puestos = db.Puestos.ToList(),
                Niveles = db.Niveles.ToList(),
                Capacitaciones = db.Capacitaciones.ToList(),
                Experiencias = db.ExpLaboral.ToList(),
            };

            if (viewModel.Candidatos == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Candidatos/Create
        public ActionResult Create()
        {
            var viewModel = new CandidatosViewModel()
            {
                Candidatos = new Candidato(),
                Puestos = db.Puestos.ToList(),
                Niveles = db.Niveles.ToList(),
                Capacitaciones = db.Capacitaciones.ToList(),
                Experiencias = db.ExpLaboral.ToList()
            };
            return View(viewModel);
        }

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

        //GET: Candidatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new CandidatosViewModel()
            {
                Candidatos = db.Candidatos.Find(id),
                Puestos = db.Puestos.ToList(),
                Niveles = db.Niveles.ToList(),
                Capacitaciones = db.Capacitaciones.ToList(),
                Experiencias = db.ExpLaboral.ToList()
            };

            if (viewModel.Candidatos == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Edit(CandidatosViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                db.Entry(viewModel.Candidatos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", viewModel);
        }


        // GET: Candidatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new CandidatosViewModel()
            {
                Candidatos = db.Candidatos.Find(id),
            };
            if (viewModel.Candidatos == null)
            {
                return HttpNotFound();
            }
            return View("Delete", viewModel);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var viewModel = new CandidatosViewModel()
            {
                Candidatos = db.Candidatos.Find(id),
            };
            db.Candidatos.Remove(viewModel.Candidatos);
            db.SaveChanges();
            return RedirectToAction("Index");
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
