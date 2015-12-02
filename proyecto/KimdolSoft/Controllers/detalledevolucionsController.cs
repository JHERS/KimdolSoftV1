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
    public class detalledevolucionsController : Controller
    {
        private kimdolsoftEntities db = new kimdolsoftEntities();

        // GET: detalledevolucions
        public ActionResult Index()
        {
            var detalledevolucion = db.detalledevolucion.Include(d => d.devolucion).Include(d => d.producto);
            return View(detalledevolucion.ToList());
        }

        // GET: detalledevolucions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalledevolucion detalledevolucion = db.detalledevolucion.Find(id);
            if (detalledevolucion == null)
            {
                return HttpNotFound();
            }
            return View(detalledevolucion);
        }

        // GET: detalledevolucions/Create
        public ActionResult Create()
        {
            ViewBag.idDevolucion = new SelectList(db.devolucion, "idDevolucion", "idProveedor");
            ViewBag.idProducto = new SelectList(db.producto, "idProducto", "nombre");
            return View();
        }

        // POST: detalledevolucions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Devolucion_Detalle devolucionDetalle)
        {
            if (ModelState.IsValid)
            {
                db.devolucion.Add(devolucionDetalle.devolucion);
                db.SaveChanges();
                devolucionDetalle.devolucion.idDevolucion = devolucionDetalle.dtDevolucion.idDevolucion;
                db.detalledevolucion.Add(devolucionDetalle.dtDevolucion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: detalledevolucions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalledevolucion detalledevolucion = db.detalledevolucion.Find(id);
            if (detalledevolucion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDevolucion = new SelectList(db.devolucion, "idDevolucion", "idProveedor", detalledevolucion.idDevolucion);
            ViewBag.idProducto = new SelectList(db.producto, "idProducto", "nombre", detalledevolucion.idProducto);
            return View(detalledevolucion);
        }

        // POST: detalledevolucions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalle,idProducto,idDevolucion,descripcion,cantidadADevolver,cantidadPendiente")] detalledevolucion detalledevolucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalledevolucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDevolucion = new SelectList(db.devolucion, "idDevolucion", "idProveedor", detalledevolucion.idDevolucion);
            ViewBag.idProducto = new SelectList(db.producto, "idProducto", "nombre", detalledevolucion.idProducto);
            return View(detalledevolucion);
        }

        // GET: detalledevolucions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalledevolucion detalledevolucion = db.detalledevolucion.Find(id);
            if (detalledevolucion == null)
            {
                return HttpNotFound();
            }
            return View(detalledevolucion);
        }

        // POST: detalledevolucions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalledevolucion detalledevolucion = db.detalledevolucion.Find(id);
            db.detalledevolucion.Remove(detalledevolucion);
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
