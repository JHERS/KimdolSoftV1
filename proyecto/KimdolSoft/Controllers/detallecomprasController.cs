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
    public class detallecomprasController : Controller
    {
        private kimdolsoftEntities db = new kimdolsoftEntities();

        // GET: detallecompras
        public ActionResult Index()
        {
            var detallecompra = db.detallecompra.Include(d => d.compra).Include(d => d.producto);
            return View(detallecompra.ToList());
        }

        // GET: detallecompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detallecompra detallecompra = db.detallecompra.Find(id);
            if (detallecompra == null)
            {
                return HttpNotFound();
            }
            return View(detallecompra);
        }

        // GET: detallecompras/Create
        public ActionResult Create()
        {
            ViewBag.idCompra = new SelectList(db.compra, "idCompra", "idProveedor");
            ViewBag.idProducto = new SelectList(db.producto, "idProducto", "nombre");
            return View();
        }

        // POST: detallecompras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalle,idProducto,idCompra,cantidad,valorUnitario")] detallecompra detallecompra)
        {
            if (ModelState.IsValid)
            {
                db.detallecompra.Add(detallecompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCompra = new SelectList(db.compra, "idCompra", "idProveedor", detallecompra.idCompra);
            ViewBag.idProducto = new SelectList(db.producto, "idProducto", "nombre", detallecompra.idProducto);
            return View(detallecompra);
        }

        // GET: detallecompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detallecompra detallecompra = db.detallecompra.Find(id);
            if (detallecompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCompra = new SelectList(db.compra, "idCompra", "idProveedor", detallecompra.idCompra);
            ViewBag.idProducto = new SelectList(db.producto, "idProducto", "nombre", detallecompra.idProducto);
            return View(detallecompra);
        }

        // POST: detallecompras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalle,idProducto,idCompra,cantidad,valorUnitario")] detallecompra detallecompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallecompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCompra = new SelectList(db.compra, "idCompra", "idProveedor", detallecompra.idCompra);
            ViewBag.idProducto = new SelectList(db.producto, "idProducto", "nombre", detallecompra.idProducto);
            return View(detallecompra);
        }

        // GET: detallecompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detallecompra detallecompra = db.detallecompra.Find(id);
            if (detallecompra == null)
            {
                return HttpNotFound();
            }
            return View(detallecompra);
        }

        // POST: detallecompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detallecompra detallecompra = db.detallecompra.Find(id);
            db.detallecompra.Remove(detallecompra);
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
