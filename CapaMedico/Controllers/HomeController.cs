using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Capa_Entidad;
using Capa_Negocio;
namespace CapaMedico.Controllers
{
    public class HomeController : Controller
    {

        [Authorize]

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Paciente()
        {
            return View();
        }
        public ActionResult Solicitud()
        {
            return View();
        }
        public ActionResult PagoMensualidad()
        {
            return View();
        }
        public ActionResult Donaciones()
        {
            return View();
        }
        public ActionResult GastoFundacion()
        {
            return View();
        }
        public ActionResult Ficha()
        {
            return View();
        }


        [HttpGet]
        public JsonResult ListarGastosFundacion()
        {
            List<GastosFundacion> oLista = new List<GastosFundacion>();

            oLista = new CN_GastosFundacion().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListarPaciente()
        {
            List<Paciente> oLista = new List<Paciente>();

            oLista = new CN_Paciente().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarCiat()
        {
            List<Cita> oLista = new List<Cita>();

            oLista = new CN_Cita().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }





        [HttpPost]
        public JsonResult GuardarGastoFundacion(GastosFundacion objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.NoGasto == 0)
            {

                resultado = new CN_GastosFundacion().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_GastosFundacion().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GuardarPaciente(Paciente objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.NoPaciente == 0)
            {

                resultado = new CN_Paciente().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Paciente().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GuardarCita(Cita objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdCita == 0)
            {

                resultado = new CN_Cita().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Cita().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult EliminarGastoFundacion(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_GastosFundacion().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarPaciente(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Paciente().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Eliminarcita(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new  CN_Cita().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }







    }
}