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
    public class IdiomasController : Controller
    {
        private Context db = new Context();

        // GET: Idiomas
        public ActionResult Index()
        {
            var Idiomas = db.Idiomas.Include(c => c.Estado);

            return View(Idiomas.ToList());
        }

        // GET: Idiomas/Create
        public ActionResult Create()
        {
            var ViewModel = new IdiomasViewModel
            {
                Estados = db.Estados.ToList()
            };

            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Create(IdiomasViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Idiomas.Add(viewModel.Idiomas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", viewModel);
        }

        // GET: Idiomas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new IdiomasViewModel
            {
                Idiomas = db.Idiomas.Find(id),
                Estados = db.Estados.ToList()
            };
            if (viewModel.Idiomas == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(IdiomasViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ViewModel.Idiomas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ViewModel);
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
