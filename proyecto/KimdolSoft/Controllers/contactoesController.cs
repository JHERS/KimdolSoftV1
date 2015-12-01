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
    public class contactoesController : Controller
    {
        private kimdolsoftEntities db = new kimdolsoftEntities();

        

        // GET: contactoes
        public ActionResult Index()
        {
            var contacto = db.contacto.Include(c => c.proveedor);
            return View(contacto.ToList());
        }

        // GET: contactoes/Details/5
        public JsonResult validacionContacto(string idContacto)
        {
            var obj = db.contacto.Where(x => x.idContacto == idContacto).FirstOrDefault();
            if (obj == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json("El documento de identidad del contacto ya se encuentra registrado", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto contacto = db.contacto.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // GET: contactoes/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.proveedor, "idProveedor", "tipoDocumento");
            return View();
        }

        // POST: contactoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idContacto,tipoDocumento,primerNombre,segundoNombre,primerApellido,segundoApellido,celular,email,idProveedor")] contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.contacto.Add(contacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.proveedor, "idProveedor", "tipoDocumento", contacto.idProveedor);
            return View(contacto);
        }

        // GET: contactoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto contacto = db.contacto.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.proveedor, "idProveedor", "tipoDocumento", contacto.idProveedor);
            return View(contacto);
        }

        // POST: contactoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idContacto,tipoDocumento,primerNombre,segundoNombre,primerApellido,segundoApellido,celular,email,idProveedor")] contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.proveedor, "idProveedor", "tipoDocumento", contacto.idProveedor);
            return View(contacto);
        }

        // GET: contactoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto contacto = db.contacto.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: contactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            contacto contacto = db.contacto.Find(id);
            db.contacto.Remove(contacto);
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
