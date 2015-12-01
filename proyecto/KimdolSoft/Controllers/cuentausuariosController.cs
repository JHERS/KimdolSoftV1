using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KimdolSoft.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace KimdolSoft.Controllers
{
    public class cuentausuariosController : Controller
    {
        private kimdolsoftEntities db = new kimdolsoftEntities();

        MD5 md = new MD5CryptoServiceProvider();

        // GET: cuentausuarios
        public ActionResult Index()
        {
            var cuentausuario = db.cuentausuario.Include(c => c.empleado);
            return View(cuentausuario.ToList());
        }

        // GET: cuentausuarios/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentausuario cuentausuario = db.cuentausuario.Find(id);
            if (cuentausuario == null)
            {
                return HttpNotFound();
            }
            return View(cuentausuario);
        }

        
        // GET: cuentausuarios/Create
        public ActionResult Create()
        {

            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "idEmpleado");
            return View();
        }
        

        // POST: cuentausuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCuentaUsuario,nombreUsuario,contrasena,preguntaSeguridad,respuestaSeguridad,idEmpleado")] cuentausuario cuentausuario)
        {
            if (ModelState.IsValid)
            {

               /* Byte[] original = ASCIIEncoding.Default.GetBytes(cuentausuario.contrasena);
                Byte[] encodedBytes = md.ComputeHash(original);
                cuentausuario.contrasena = BitConverter.ToString(encodedBytes);*/
                db.cuentausuario.Add(cuentausuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "idEmpleado", cuentausuario.idEmpleado);
            return View(cuentausuario);
        }

        // GET: cuentausuarios/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentausuario cuentausuario = db.cuentausuario.Find(id);
            if (cuentausuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "idEmpleado", cuentausuario.idEmpleado);
            return View(cuentausuario);
        }

        // POST: cuentausuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCuentaUsuario,nombreUsuario,contrasena,preguntaSeguridad,respuestaSeguridad,idEmpleado")] cuentausuario cuentausuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentausuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "idEmpleado", cuentausuario.idEmpleado);
            return View(cuentausuario);
        }

        // GET: cuentausuarios/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentausuario cuentausuario = db.cuentausuario.Find(id);
            if (cuentausuario == null)
            {
                return HttpNotFound();
            }
            return View(cuentausuario);
        }

        // POST: cuentausuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            cuentausuario cuentausuario = db.cuentausuario.Find(id);
            db.cuentausuario.Remove(cuentausuario);
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
