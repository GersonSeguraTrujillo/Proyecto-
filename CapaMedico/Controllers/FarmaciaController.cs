using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Capa_Entidad;
using Capa_Negocio;

namespace CapaMedico.Controllers
{
    public class FarmaciaController : Controller
    {
        // GET: Farmacia
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Medicamentos()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarMedicamento()
        {
            List<Medicamento> oLista = new List<Medicamento>();

            oLista = new CN_Medicamento().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarMedicamento(Medicamento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdDescripcionCita == 0)
            {

                resultado = new CN_Medicamento().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Medicamento().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult EliminarMedicamenton(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Medicamento().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }




    }
}