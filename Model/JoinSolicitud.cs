using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JoinSolicitud
    {
        public int IdSolicitud { get; set; }
        public string NombreEntidad { get; set; }
        public string  NombreSolicitante { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_Recoleccion { get; set; }
        public int IdEstado_Solicitud { get; set; }
        public string strEstado_Solicitud { get; set; }
        public string LNG { get; set; }
        public string LTD { get; set; }
    }
}
