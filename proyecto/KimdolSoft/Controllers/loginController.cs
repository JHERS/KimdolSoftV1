using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KimdolSoft.Models;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace KimdolSoft.Controllers
{
    public class loginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        MD5 md = new MD5CryptoServiceProvider();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(cuentausuario u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                using (kimdolsoftEntities db = new kimdolsoftEntities())
                {
                    Byte[] original = ASCIIEncoding.Default.GetBytes(u.contrasena);
                    Byte[] encodedBytes = md.ComputeHash(original);
                    string contrasenia = BitConverter.ToString(encodedBytes);
                    var v = db.cuentausuario.Where(a => a.nombreUsuario.Equals(u.nombreUsuario) && a.contrasena.Equals(contrasenia)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.idCuentaUsuario.ToString();
                        Session["LogedUserFullname"] = v.nombreUsuario.ToString();
                        return RedirectToAction("../contactoes");
                    }
                }
            }
            return View(u);
        }
    }
}
