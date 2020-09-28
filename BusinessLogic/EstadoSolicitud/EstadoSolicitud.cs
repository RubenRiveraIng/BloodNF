using DAO;
using DAO.EstadoSolicitudOp;

namespace BusinessLogic.EstadoSolicitud
{
    public  class EstadoSolicitud
    {
        private IEstadoSolicitudOperations _operations;
        public EstadoSolicitud(bloodbog_bdEntities context)
        {
            this._operations = new EstadoSolicitudOperations(context);
        }

        public dynamic getEstadoSolicitud()
        {
            return _operations.getEstadoSolicitud();
        }

    }
}
