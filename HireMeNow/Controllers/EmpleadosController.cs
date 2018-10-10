using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using HireMeNow.DAL;
using HireMeNow.Models;
using HireMeNow.ViewModel;

namespace HireMeNow.Controllers
{
    public class EmpleadosController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            var Empleado = db.Empleados
                .Include(c => c.Puestos)
                .Include(c => c.Estados);

            return View(Empleado.ToList());
        }

        public ActionResult exportReport()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "Empleados.rpt"));
            rd.SetDataSource(db.Empleados.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Employee_list.pdf");
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        public ActionResult NewEmpleado(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Candidatos = db.Candidatos.Find(id);

            var Empleado = new Empleado()
            {
                Cedula = Candidatos.Cedula,
                Nombres = Candidatos.Nombres,
                Apellidos = Candidatos.Apellidos,
                PuestosId = Candidatos.PuestosId,
                Email = Candidatos.Email,
                SalarioMensual = Candidatos.Salario,
            };

            if (ModelState.IsValid)
            {
                db.Empleados.Add(Empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index", Empleado);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new EmpleadosViewModel()
            {
                Empleados = db.Empleados.Find(id),
                Puestos = db.Puestos.ToList(),
                Estados = db.Estados.ToList(),
                Departamentos = db.Departamentos.ToList()
            };


            if (viewModel.Empleados == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        //GET: Candidatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new EmpleadosViewModel()
            {
                Empleados = db.Empleados.Find(id),
                Puestos = db.Puestos.ToList(),
                Estados = db.Estados.ToList(),
                Departamentos = db.Departamentos.ToList()
            };

            if (viewModel.Empleados == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EmpleadosViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                db.Entry(viewModel.Empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", viewModel);
        }
    }
}