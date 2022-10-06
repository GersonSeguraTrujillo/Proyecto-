using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Capa_Entidad;
using Capa_Negocio;

namespace CapaMedico.Controllers
{
    public class HorarioController : Controller
    {
        // GET: Horario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Turno()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarTurno()
        {
            List<Turno> oLista = new List<Turno>();

            oLista = new CN_Turno().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarSolitudes()
        {
            List<AsignarHorario> oLista = new List<AsignarHorario>();

            oLista = new CN_AsignacionHorarios().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
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
        public JsonResult AsignarHorario(AsignarHorario objeto)
        {
            object resultado;
            string mensaje = string.Empty;


            if (objeto.IdCita == 0)
            {

                resultado = new CN_AsignacionHorarios().AsignacionHorario(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_AsignacionHorarios().AsignacionHorario(objeto, out mensaje);

            }




            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }




        [HttpPost]
        public JsonResult EliminarTurno(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Turno().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }




    }
}