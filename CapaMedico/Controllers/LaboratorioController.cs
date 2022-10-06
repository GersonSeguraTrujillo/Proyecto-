using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using Capa_Negocio;

namespace CapaMedico.Controllers
{
    public class LaboratorioController : Controller
    {
        // GET: Laboratorio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Examenes()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarExamen()
        {
            List<Examen> oLista = new List<Examen>();

            oLista = new CN_Examen().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarExamen(Examen objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdDescripcionCita == 0)
            {

                resultado = new CN_Examen().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Examen().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult DarResultado(DarResultados objeto)
        {
            object resultado;
            string mensaje = string.Empty;


              resultado = new CN_Cita().DarResultado(objeto, out mensaje);

            

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult EliminarExamen(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Examen().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
}