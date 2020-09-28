using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DAO.LineasAtencionOp;

namespace BusinessLogic.LineasAtencion
{
    public class LineasAtencion
    {
        private ILineasAtencionOperations _operations;
        public LineasAtencion(bloodbog_bdEntities context)
        {
            this._operations = new LineasAtencionOperations(context);
        }

        public dynamic getLineas_Atencion()
        {
            return _operations.GetLineas_Atencions();
        }

    }
}
