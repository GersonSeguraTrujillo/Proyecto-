using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using Capa_Entidad;
using Capa_Negocio;

namespace CapaMedico.Controllers
{
    public class LoginEspecialistaController : Controller
    {
        // GET: LoginEspecialista
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string email, String clave)
        {
            Usuario oUsuario = new Usuario();

            oUsuario = new CN_Usuarios().Listar().Where(u => u.Correo == email && u.Contraseña == clave && u.rol == 3).FirstOrDefault();



            if (oUsuario == null)
            {
                ViewBag.error = "Correo o contraseña incorrecta, Intentelo de nuevo";
                return View();
            }
            else
            {
               
               

                    FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                    ViewBag.error = null;
                    return RedirectToAction("Index", "Especialista");

           



            }


        }

        public ActionResult Cerrar_Sesion()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "LoginEspecialista");

        }




    }
}