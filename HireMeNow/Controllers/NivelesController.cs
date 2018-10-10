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
    public class NivelesController : Controller
    {
        private Context db = new Context();

        // GET: Niveles
        public ActionResult Index()
        {
            return View(db.Niveles.ToList());
        }

        // GET: Niveles/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Nombre,Creado")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                db.Niveles.Add(nivel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivel);
        }

        // GET: Niveles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Niveles.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Creado")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivel);
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
