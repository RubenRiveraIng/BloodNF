using System.Collections.Generic;
using System.Linq;
namespace DAO.LineasAtencionOp
{
    public class LineasAtencionOperations:ILineasAtencionOperations
    {
        private readonly bloodbog_bdEntities _context;
        public LineasAtencionOperations(bloodbog_bdEntities context)
        {
            this._context = context;
            this._context.Configuration.ProxyCreationEnabled = false;
        }
        public List<Lineas_Atencion> GetLineas_Atencions()
        {
            return _context.Lineas_Atencion.ToList();

        }
    }
}
