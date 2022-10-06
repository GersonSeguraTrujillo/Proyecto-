using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Capa_Entidad;
using Capa_Negocio;

namespace CapaMedico.Controllers
{
    public class MantenimientoController : Controller
    {
        [Authorize]
        // GET: Mantenimiento
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }
        public ActionResult Medico()
        {
            return View();
        }
        public ActionResult Especialistas()
        {
            return View();
        }
        public ActionResult Enfermeros()
        {
            return View();
        }
        public ActionResult Fundacion()
        {
            return View();
        }
        public ActionResult Gastos()
        {
            return View();
        }
        public ActionResult Especialidades()
        {
            return View();
        }
        public ActionResult Mes()
        {
            return View();
        }

        public ActionResult Turno()
        {
            return View();
        }
        public ActionResult Estado()
        {
            return View();
        }
        public ActionResult Prueba()
        {
            return View();
        }



        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> oLista = new List<Usuario>();

            oLista = new CN_Usuarios().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarMedico()
        {
            List<Medico> oLista = new List<Medico>();

            oLista = new CN_Medico().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarEspecialidad()
        {
            List<Especialidad> oLista = new List<Especialidad>();

            oLista = new CN_Especialidad().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListarMes()
        {
            List<Mes> oLista = new List<Mes>();

            oLista = new CN_Mes().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarTurno()
        {
            List<Turno> oLista = new List<Turno>();

            oLista = new CN_Turno().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListarEstado()
        {
            List<Estado> oLista = new List<Estado>();

            oLista = new CN_Estado().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListarEspecialista()
        {
            List<Especialista> oLista = new List<Especialista>();

            oLista = new CN_Especialista().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarEnfermero()
        {
            List<Enfermero> oLista = new List<Enfermero>();

            oLista = new CN_Enfermero().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarFundacion()
        {
            List<Fundacion> oLista = new List<Fundacion>();

            oLista = new CN_Fundacion().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListarGasto()
        {
            List<Gastos> oLista = new List<Gastos>();

            oLista = new CN_Gasto().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }







        [HttpPost]
        public JsonResult GuardarUsuario(Usuario objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdUsuario == 0)
            {

                resultado = new CN_Usuarios().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Usuarios().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GuardarMedico(Medico objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdMedico == 0)
            {

                resultado = new CN_Medico().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Medico().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }



        [HttpPost]
        public JsonResult GuardarEspecialidad(Especialidad objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdEspecialidad == 0)
            {

                resultado = new CN_Especialidad().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Especialidad().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult GuardarMes(Mes objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdMes == 0)
            {

                resultado = new CN_Mes().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Mes().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult GuardarTurno(Turno objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.NoTurno == 0)
            {

                resultado = new CN_Turno().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Turno().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GuardarEstado(Estado objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdEstado == 0)
            {

                resultado = new CN_Estado().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Estado().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GuardarEspecialista(Especialista objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdEspecialista == 0)
            {

                resultado = new CN_Especialista().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Especialista().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GuardarEnfermero(Enfermero objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdEnfermero == 0)
            {

                resultado = new CN_Enfermero().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Enfermero().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GuardarFundacion(Fundacion objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdFundacion == 0)
            {

                resultado = new CN_Fundacion().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Fundacion().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GuardarGasto(Gastos objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdGasto == 0)
            {

                resultado = new CN_Gasto().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Gasto().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }







        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Usuarios().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarMedico(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Medico().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarEspecialidad(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Especialidad().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarMes(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Mes().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTurno(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Turno().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EliminarEstado(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Estado().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarEspecialista(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Especialista().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EliminarEnfermero(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Enfermero().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarFundacion(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Fundacion().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarGasto(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Gasto().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



    




    }
}