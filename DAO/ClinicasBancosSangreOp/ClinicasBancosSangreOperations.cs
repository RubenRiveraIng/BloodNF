using System.Collections.Generic;
using System.Linq;
namespace DAO.ClinicasBancosSangreOp
{
    public class ClinicasBancosSangreOperations:IClinicasBancosSangreOperations
    {
        private readonly bloodbog_bdEntities _context;
        public ClinicasBancosSangreOperations(bloodbog_bdEntities context)
        {
            this._context = context;
            this._context.Configuration.ProxyCreationEnabled = false;
        }
        public List<Clinicas_Bancos_Sangre> getClinicasBancosSangre()
        {
            return _context.Clinicas_Bancos_Sangre.ToList();
        }
    }
}
