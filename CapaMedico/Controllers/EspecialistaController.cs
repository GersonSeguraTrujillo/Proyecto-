using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



using Capa_Entidad;
using Capa_Negocio;

namespace CapaMedico.Controllers
{
    public class EspecialistaController : Controller
    {
        // GET: Especialista
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MedicamentoExamanen()
        {
            return View();
        }
        public ActionResult AsignacionMedicamento()
        {
            return View();
        }



        [HttpGet]
         public JsonResult BuscarPaciente(int IdCita)
        {
            List<BuscarPaciente> olista = new List<BuscarPaciente>();
            olista = new CN_BuscarPaciente().Buscar(IdCita);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult VistaPaciente( int IdCita)
        {
            BuscarPaciente objeto = new CN_BuscarPaciente().VerPaciente(IdCita);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult VistaFicha (int IdCita)
        {
            BuscarFicha objeto = new CN_BuscarFicha().VerFicha(IdCita);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public JsonResult ListaGastosMedicos(int IdCita)
        {
            List<GastosMedicos> olista = new List<GastosMedicos>();
            olista = new CN_GastosMedicos().ListarGastosMedicos(IdCita);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult ListarAgendaDeEspecialista(int IdEspecialidad)
        {
            List<AgendaDeEspecialista> olista = new List<AgendaDeEspecialista>();
            olista = new CN_AgendaDeEspecialista().ListarAgendaEspecialista(IdEspecialidad);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult ListaMedicamento(int IdCita)
        {
            List<GastosMedicos> olista = new List<GastosMedicos>();
            olista = new CN_GastosMedicos().ListarMedicamento(IdCita);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult RegistrarGastoMedico(GastosMedicos objeto)
        {
          
            object resultado;
            string mensaje = string.Empty;

          
                resultado = new CN_GastosMedicos().Registrar(objeto, out mensaje);

            

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }



        [HttpPost]
        public JsonResult EliminarGastos (int id,int i)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_GastosMedicos().Eliminar(id,i, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }





        [HttpPost]
        public JsonResult ActualizacionEstadoCita(ActualizarEstado objeto)
        {
            object resultado;
            string mensaje = string.Empty;


            resultado = new CN_Cita().ActualizacionEstadoCita(objeto, out mensaje);



            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }




    }
}