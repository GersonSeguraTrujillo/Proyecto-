using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{

//    IdUsuario int identity(1,1) primary key not null,
//Nombre Nvarchar(40) null,
//Apellido Nvarchar(40) null,
//Contraseña Nvarchar(600) null
   public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int rol { get; set; }

    }
}
