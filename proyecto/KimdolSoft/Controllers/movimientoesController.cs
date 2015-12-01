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
    public class movimientoesController : Controller
    {
        private kimdolsoftEntities db = new kimdolsoftEntities();

        // GET: movimientoes
        public ActionResult Index()
        {
            var movimiento = db.movimiento.Include(m => m.cliente).Include(m => m.empleado).Include(m => m.tipomovimiento);
            return View(movimiento.ToList());
        }

        // GET: movimientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movimiento movimiento = db.movimiento.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // GET: movimientoes/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "idCliente");
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "idEmpleado");
            ViewBag.idTipoMovimiento = new SelectList(db.tipomovimiento, "idTipoMovimiento", "nombre");
            return View();
        }

        // POST: movimientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMovimiento,fechaVenta,fechaEntrega,descuento,idCliente,idEmpleado,idTipoMovimiento,valorTotal,estado")] movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                db.movimiento.Add(movimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "idCliente", movimiento.idCliente);
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "idEmpleado", movimiento.idEmpleado);
            ViewBag.idTipoMovimiento = new SelectList(db.tipomovimiento, "idTipoMovimiento", "nombre", movimiento.idTipoMovimiento);
            return View(movimiento);
        }

        // GET: movimientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movimiento movimiento = db.movimiento.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "idCliente", movimiento.idCliente);
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "idEmpleado", movimiento.idEmpleado);
            ViewBag.idTipoMovimiento = new SelectList(db.tipomovimiento, "idTipoMovimiento", "nombre", movimiento.idTipoMovimiento);
            return View(movimiento);
        }

        // POST: movimientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMovimiento,fechaVenta,fechaEntrega,descuento,idCliente,idEmpleado,idTipoMovimiento,valorTotal,estado")] movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.cliente, "idCliente", "idCliente", movimiento.idCliente);
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "idEmpleado", movimiento.idEmpleado);
            ViewBag.idTipoMovimiento = new SelectList(db.tipomovimiento, "idTipoMovimiento", "nombre", movimiento.idTipoMovimiento);
            return View(movimiento);
        }

        // GET: movimientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movimiento movimiento = db.movimiento.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // POST: movimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            movimiento movimiento = db.movimiento.Find(id);
            db.movimiento.Remove(movimiento);
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
