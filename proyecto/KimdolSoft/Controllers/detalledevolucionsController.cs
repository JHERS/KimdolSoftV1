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

        public ActionResult prueba()
        {
             
            return RedirectToAction("Index");
        }

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
            ViewData["IdProductoSeleccionado"] = String.Empty;
            ViewData["IdProveedorSeleccionado"] = String.Empty;
            ViewBag.idProveedor = db.proveedor.ToList();
            ViewBag.idProducto = db.producto.ToList();
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
                devolucionDetalle.dtDevolucion.idDevolucion = devolucionDetalle.devolucion.idDevolucion;
                db.detalledevolucion.Add(devolucionDetalle.dtDevolucion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["IdProductoSeleccionado"] = devolucionDetalle.dtDevolucion.idProducto;
            ViewData["IdProveedorSeleccionado"] = devolucionDetalle.devolucion.idProveedor;
            ViewBag.idProveedor = db.proveedor.ToList();
            ViewBag.idProducto = db.producto.ToList();
            return View(devolucionDetalle);
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
            ViewData["IdProductoSeleccionado"] = String.Empty;
            ViewData["IdProveedorSeleccionado"] = String.Empty;
            ViewBag.idProveedor = db.proveedor.ToList();
            ViewBag.idProducto = db.producto.ToList();
            return View(new Devolucion_Detalle() { dtDevolucion = detalledevolucion, devolucion = detalledevolucion.devolucion });
        }

        // POST: detalledevolucions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "idDetalle,idProducto,idDevolucion,descripcion,cantidadADevolver,cantidadPendiente")] detalledevolucion detalledevolucion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(detalledevolucion).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.idDevolucion = new SelectList(db.devolucion, "idDevolucion", "idProveedor", detalledevolucion.idDevolucion);
        //    ViewBag.idProducto = new SelectList(db.producto, "idProducto", "nombre", detalledevolucion.idProducto);
        //    return View(detalledevolucion);
        //}
               
        


        public ActionResult Edit([Bind(Prefix = "devolucion")] devolucion devolucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devolucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.proveedor, "idProveedor", "idProveedor", devolucion);
            return View(devolucion);
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
