using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO.SolicitudRecoleccionOp
{
    public interface ISolicitudRecoleccionOperations
    {
        List<JoinSolicitud> getSolicitudesPorUsuarioRegular(int IdUsuario);
        List<JoinSolicitud> getSolicitudPorUsuarioEntidad(int IdUsuario);
        int createSolicitudRecoleccion(Solicitud_Recoleccion data);
        List<JoinSolicitud> getSolicitudPorUsuarioEntidadById(int IdSolicitud);
    }
}
