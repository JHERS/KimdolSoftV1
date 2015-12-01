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
    public class devolucionsController : Controller
    {
        private kimdolsoftEntities db = new kimdolsoftEntities();

        // GET: devolucions
        public ActionResult Index()
        {
            var devolucion = db.devolucion.Include(d => d.proveedor);
            return View(devolucion.ToList());
        }

        // GET: devolucions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            devolucion devolucion = db.devolucion.Find(id);
            if (devolucion == null)
            {
                return HttpNotFound();
            }
            return View(devolucion);
        }

        // GET: devolucions/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.proveedor, "idProveedor", "idProveedor");
            return View();
        }

        // POST: devolucions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDevolucion,fechaDevolucion,idProveedor,estado")] devolucion devolucion)
        {
            if (ModelState.IsValid)
            {
                db.devolucion.Add(devolucion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.proveedor, "idProveedor", "idProveedor", devolucion.idProveedor);
            return View(devolucion);
        }

        // GET: devolucions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            devolucion devolucion = db.devolucion.Find(id);
            if (devolucion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.proveedor, "idProveedor", "idProveedor", devolucion.idProveedor);
            return View(devolucion);
        }

        // POST: devolucions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDevolucion,fechaDevolucion,idProveedor,estado")] devolucion devolucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devolucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.proveedor, "idProveedor", "idProveedor", devolucion.idProveedor);
            return View(devolucion);
        }

        // GET: devolucions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            devolucion devolucion = db.devolucion.Find(id);
            if (devolucion == null)
            {
                return HttpNotFound();
            }
            return View(devolucion);
        }

        // POST: devolucions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            devolucion devolucion = db.devolucion.Find(id);
            db.devolucion.Remove(devolucion);
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
