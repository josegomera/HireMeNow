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
    public class PuestosController : Controller
    {
        private Context db = new Context();

        // GET: Puestos
        public ActionResult Index()
        {
            var puestos = db.Puestos
                .Include(p => p.Competencias)
                .Include(p => p.Departamentos)
                .Include(p => p.NivelRiesgos)
                .Include(p => p.Estados);
            return View(puestos.ToList());
        }

        // GET: Puestoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ViewModel = new PuestoViewModel
            {
                Puestos = db.Puestos.Find(id),
                NivelR = db.Riesgos.ToList(),
                Competencias = db.Competencias.ToList(),
                Departamentos = db.Departamentos.ToList(),
                Estados = db.Estados.ToList()
            };
            if (ViewModel.Puestos == null)
            {
                return HttpNotFound();
            }
            return View("Details", ViewModel);
        }

        // GET: Puestos/Create
        public ActionResult Create()
        {
            var ViewModel = new PuestoViewModel
            {
                NivelR = db.Riesgos.ToList(),
                Competencias = db.Competencias.ToList(),
                Departamentos = db.Departamentos.ToList(),
                Estados = db.Estados.ToList()
            };

            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Create(PuestoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Puestos.Add(viewModel.Puestos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", viewModel);
        }

        // GET: Puestos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ViewModel = new PuestoViewModel
            {
                Puestos = db.Puestos.Find(id),
                NivelR = db.Riesgos.ToList(),
                Competencias = db.Competencias.ToList(),
                Departamentos = db.Departamentos.ToList(),
                Estados = db.Estados.ToList()
            };
 
            if (ViewModel.Puestos == null)
            {
                return HttpNotFound();
            }

            return View("Edit", ViewModel);
        }

        [HttpPost]
        public ActionResult Edit(PuestoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewModel.Puestos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Puestos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ViewModel = new PuestoViewModel
            {
                Puestos = db.Puestos.Find(id),
            };
            if (ViewModel.Puestos == null)
            {
                return HttpNotFound();
            }
            return View("Delete", ViewModel);
        }

        // POST: Puestos/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var ViewModel = new PuestoViewModel
            {
                Puestos = db.Puestos.Find(id),
            };
            db.Puestos.Remove(ViewModel.Puestos);
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
