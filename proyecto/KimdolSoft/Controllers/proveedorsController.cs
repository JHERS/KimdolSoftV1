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
    public class proveedorsController : Controller
    {
        private kimdolsoftEntities db = new kimdolsoftEntities();

        
        // GET: proveedors
        public ActionResult Index()
        {
            var mensajeRegistro = TempData["mensajeRegistro"];
            ViewBag.mensajeRegistro = mensajeRegistro;
            var mensajeEditar = TempData["mensajeEditar"];
            ViewBag.mensajeEditar = mensajeEditar;
            var mensajeEliminar = TempData["mensajeEliminar"];
            ViewBag.mensajeEliminar = mensajeEliminar;
            return View(db.proveedor.ToList());
        }

        // GET: proveedors/Details/5

        
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: proveedors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: proveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProveedor,tipoDocumento,empresa,direccionEmpresa,emailEmpresa,telefonoEmpresa, nombreVendedor, apellidoVendedor, telefonoVendedor,estado")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                var existe = db.proveedor.Where(x => x.idProveedor == proveedor.idProveedor).FirstOrDefault();
                if (existe == null)
                {
                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                    TempData["mensajeRegistro"] = "Registro exitoso";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "El proveedor ya se encuentra registrado");
            }

            return View(proveedor);
        }

        // GET: proveedors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: proveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProveedor,tipoDocumento,empresa,direccionEmpresa,emailEmpresa,telefonoEmpresa, nombreVendedor, apellidoVendedor, telefonoVendedor,estado")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensajeEditar"] = "Modificación exitosa";
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        // GET: proveedors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            proveedor proveedor = db.proveedor.Find(id);
            db.proveedor.Remove(proveedor);
            db.SaveChanges();
            TempData["mensajeEliminar"] = "Eliminación exitosa";
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
