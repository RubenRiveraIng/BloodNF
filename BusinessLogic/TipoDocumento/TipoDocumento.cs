using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DAO.TipoDocumentoOp;

namespace BusinessLogic.TipoDocumento
{
    public class TipoDocumento
    {
        private ITipoDocumentoOperations _operations;
        public TipoDocumento(bloodbog_bdEntities context)
        {
          this._operations = new TipoDocumentoOperations(context);
        }

        public dynamic getAll()
        {
            return _operations.getAll();
        }
    }
}
