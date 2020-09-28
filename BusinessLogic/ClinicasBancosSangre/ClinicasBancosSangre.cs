using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DAO.ClinicasBancosSangreOp;

namespace BusinessLogic.ClinicasBancosSangre
{
    public class ClinicasBancosSangre
    {
        private IClinicasBancosSangreOperations _operations;
        public ClinicasBancosSangre(bloodbog_bdEntities context)
        {
            this._operations = new ClinicasBancosSangreOperations(context);
        }
        public dynamic getClinicasBancosSangre()
        {
            return _operations.getClinicasBancosSangre();
        }
    }
}
