using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.SolicitudRecoleccionOp;
namespace BusinessLogic.SolicitudRecoleccion
{
    public class SolicitudRecoleccion
    {
        private ISolicitudRecoleccionOperations _operations;

        public SolicitudRecoleccion(bloodbog_bdEntities context)
        {
            this._operations = new SolicitudRecoleccionOperations(context);
        }

        public dynamic getSolicitudesPorUsuarioRegular(int IdUsuario)
        {
            return _operations.getSolicitudesPorUsuarioRegular(IdUsuario);
        }
        public dynamic getSolicitudPorUsuarioEntidad(int IdUsuario)
        {
            return _operations.getSolicitudPorUsuarioEntidad(IdUsuario);
        }
        public dynamic createSolicitudRecoleccion(Solicitud_Recoleccion data,int IdUsuarioSolicita)
        {
            data.IdUsuario_Solicita = IdUsuarioSolicita;
            data.IdEstado_Solicitud = 1;
            return _operations.createSolicitudRecoleccion(data);
        }

        public dynamic getSolicitudPorUsuarioEntidadById(int IdSolicitud)
        {
            return _operations.getSolicitudPorUsuarioEntidadById(IdSolicitud);
        }
    }
}
