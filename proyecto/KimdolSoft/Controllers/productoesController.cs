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
    public class productoesController : Controller
    {
        private kimdolsoftEntities db = new kimdolsoftEntities();

        // GET: productoes
        public ActionResult Index()
        {
            var producto = db.producto.Include(p => p.marca).Include(p => p.presentacion).Include(p => p.tipoproducto).Include(p => p.unidad);
            return View(producto.ToList());
        }

        // GET: productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: productoes/Create
        public ActionResult Create()
        {
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre");
            ViewBag.idPresentacion = new SelectList(db.presentacion, "idPresentacion", "nombre");
            ViewBag.idTipoProducto = new SelectList(db.tipoproducto, "idTipoProducto", "nombre");
            ViewBag.idUnidad = new SelectList(db.unidad, "idUnidad", "nombre");
            return View();
        }

        // POST: productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,nombre,valor,descripcion,idPresentacion,idTipoProducto,idMarca,idUnidad,estado")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", producto.idMarca);
            ViewBag.idPresentacion = new SelectList(db.presentacion, "idPresentacion", "nombre", producto.idPresentacion);
            ViewBag.idTipoProducto = new SelectList(db.tipoproducto, "idTipoProducto", "nombre", producto.idTipoProducto);
            ViewBag.idUnidad = new SelectList(db.unidad, "idUnidad", "nombre", producto.idUnidad);
            return View(producto);
        }

        // GET: productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", producto.idMarca);
            ViewBag.idPresentacion = new SelectList(db.presentacion, "idPresentacion", "nombre", producto.idPresentacion);
            ViewBag.idTipoProducto = new SelectList(db.tipoproducto, "idTipoProducto", "nombre", producto.idTipoProducto);
            ViewBag.idUnidad = new SelectList(db.unidad, "idUnidad", "nombre", producto.idUnidad);
            return View(producto);
        }

        // POST: productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,nombre,valor,descripcion,idPresentacion,idTipoProducto,idMarca,idUnidad,estado")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", producto.idMarca);
            ViewBag.idPresentacion = new SelectList(db.presentacion, "idPresentacion", "nombre", producto.idPresentacion);
            ViewBag.idTipoProducto = new SelectList(db.tipoproducto, "idTipoProducto", "nombre", producto.idTipoProducto);
            ViewBag.idUnidad = new SelectList(db.unidad, "idUnidad", "nombre", producto.idUnidad);
            return View(producto);
        }

        // GET: productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto producto = db.producto.Find(id);
            db.producto.Remove(producto);
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
