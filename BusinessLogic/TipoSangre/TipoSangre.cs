using DAO;
using DAO.TipoSangreOp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.TipoSangre
{
    public class TipoSangre
    {
        private ITipoSangreOperations _operations;
        public TipoSangre(bloodbog_bdEntities context)
        {
            this._operations = new TipoSangreOperations(context);
        }

        public dynamic getAll()
        {
            return _operations.getAll();
        }
    }
}
