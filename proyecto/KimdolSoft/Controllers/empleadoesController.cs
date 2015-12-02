using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KimdolSoft.Models;

namespace KimdolSoft.Controllers
{
    public class empleadoesController : Controller
    {
        private kimdolsoftEntities db = new kimdolsoftEntities();

        // GET: empleadoes
        public ActionResult Index()
        {
            var mensaje = TempData["message"];
            ViewBag.mensaje = mensaje;
            return View(db.empleado.ToList());
        }

        // GET: empleadoes/Details/5

        public JsonResult validacionEmail(string email)
        {
            var obj = db.empleado.Where(x => x.email == email).FirstOrDefault();
            if (obj == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json("Ya existe el correo, debes ingresar otro", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: empleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleado,tipoDocumento,primerNombre,segundoNombre,primerApellido,segundoApellido,rol,direccion,email,telefono,celular,estado")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.empleado.Add(empleado);
                db.SaveChanges();
                TempData["Message"] = "Empleado Registrado Correctamente";
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: empleadoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleado,tipoDocumento,primerNombre,segundoNombre,primerApellido,segundoApellido,rol,direccion,email,telefono,celular,estado")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Empleado Modificado Correctamente";
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: empleadoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            empleado empleado = db.empleado.Find(id);
            db.empleado.Remove(empleado);
            db.SaveChanges();
            TempData["Message"] = "Empleado Eliminado Correctamente";
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

        public JsonResult empleado(empleado empleado)
        {
            return ValidacionEmpleado(empleado.idEmpleado)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        public bool ValidacionEmpleado(string idEmpleado)
        {
            if (idEmpleado == null)
            {
                var empleado= db.empleado.Where(x => x.idEmpleado == idEmpleado).FirstOrDefault();
                return empleado == null;
            }
            else
            {
                var empleado = db.empleado.Where(x => x.idEmpleado != idEmpleado).FirstOrDefault();
                return empleado == null;
            }
        }

    }
}
