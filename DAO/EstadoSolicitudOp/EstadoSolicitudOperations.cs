using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EstadoSolicitudOp
{
    public class EstadoSolicitudOperations:IEstadoSolicitudOperations
    {
        private readonly bloodbog_bdEntities _context;
        public EstadoSolicitudOperations(bloodbog_bdEntities context)
        {
            this._context = context;
            this._context.Configuration.ProxyCreationEnabled = false;
        }
        public List<Estado_Solicitud> getEstadoSolicitud()
        {
            return _context.Estado_Solicitud.ToList();
        }
    }
}
