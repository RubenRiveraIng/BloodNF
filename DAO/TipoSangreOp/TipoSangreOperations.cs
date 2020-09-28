using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO.TipoSangreOp
{
    public class TipoSangreOperations:ITipoSangreOperations
    {
        private readonly bloodbog_bdEntities _context;
        public TipoSangreOperations(bloodbog_bdEntities context)
        {
            this._context = context;
            this._context.Configuration.ProxyCreationEnabled = false;
        }
        public List<Tipo_Sangre> getAll()
        {
            return _context.Tipo_Sangre.ToList();
        }

    }
}
