using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HireMeNow.DAL;
using HireMeNow.Models;

namespace HireMeNow.Controllers
{
    public class NivelRiesgosController : Controller
    {
        private Context db = new Context();

        // GET: NivelRiesgos
        public ActionResult Index()
        {
            return View(db.Riesgos.ToList());
        }

        // GET: NivelRiesgos/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Nombre,Creado")] NivelRiesgo nivelRiesgo)
        {
            if (ModelState.IsValid)
            {
                db.Riesgos.Add(nivelRiesgo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivelRiesgo);
        }

        // GET: NivelRiesgos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelRiesgo nivelRiesgo = db.Riesgos.Find(id);
            if (nivelRiesgo == null)
            {
                return HttpNotFound();
            }
            return View(nivelRiesgo);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Creado")] NivelRiesgo nivelRiesgo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivelRiesgo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelRiesgo);
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
