using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
  public   class CN_Cita
    {

        private CD_Cita objCapaDato = new CD_Cita();

        public List<Cita> Listar()
        {

            return objCapaDato.Listar();
        }

        public string Registrar(Cita obj, out string Mensaje)
        {
            Mensaje = String.Empty;


         if (string.IsNullOrEmpty(obj.Cintomas) || string.IsNullOrWhiteSpace(obj.Cintomas))
            {
                Mensaje = "Falta los cintomas del paciente";
            }
            else if (obj.oMedico.IdMedico == 0)
            {
                Mensaje = "Debe Seleccione medico";
            }
            else if (obj.oPaciente.NoPaciente == 0)
            {
                Mensaje = "Falta el paciente";
            }

            else if (obj.oEspecialista.IdEspecialista == 0)
            {
                Mensaje = "Falta el especialista";
            }
            else if (obj.oEnfermero.IdEnfermero == 0)
            {
                Mensaje = "Falta el enfermero";
            }
            else if (obj.oEstado.IdEstado == 0)
            {
                Mensaje = "Falta el estado de la cita";
            }
            else if (obj.PrecioCita == 0)
            {
                Mensaje = "Falta el precio de la cita,o a escrito letras en el vez de numeros";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return null;
            }

        }

        public bool Editar(Cita obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oMedico.IdMedico == 0)
            {
                Mensaje = "Debe Seleccione medico";
            }
            else if (obj.oPaciente.NoPaciente == 0)
            {
                Mensaje = "Falta el paciente";
            }
            else if (string.IsNullOrEmpty(obj.Cintomas) || string.IsNullOrWhiteSpace(obj.Cintomas))
            {
                Mensaje = "Falta los motivo de cita";
            }
            else if (obj.oEspecialista.IdEspecialista == 0)
            {
                Mensaje = "Falta el especialista";
            }
            else if (obj.oEnfermero.IdEnfermero == 0)
            {
                Mensaje = "Falta el enfermero";
            }
            else if (obj.oEstado.IdEstado == 0)
            {
                Mensaje = "Falta el estado de la cita";
            }
            else if (obj.PrecioCita == 0)
            {
                Mensaje = "Falta el precio de la cita";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool DarResultado(DarResultados obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.IdCita    == 0)
            {
                Mensaje = "Falta el numero de la cita ";
            }
      
            else if (string.IsNullOrEmpty(obj.Resultados) || string.IsNullOrWhiteSpace(obj.Resultados))
            {
                Mensaje = "Falta los los resultado";
            }
            


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.DarResultados(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
        

     public bool ActualizacionEstadoCita(ActualizarEstado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.IdCita == 0)
            {
                Mensaje = "Falta el numero de la cita ";
            }

            else if (obj.oEstado.IdEstado ==1 && obj.oEstado.IdEstado ==0)
            {
                Mensaje = "Debe seleccionar el estado de la cita";
            }
           


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.ActualizacionEstadoCita(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }



    }
}
