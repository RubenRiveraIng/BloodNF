using System.Collections.Generic;
using System.Linq;
namespace DAO.TipoDocumentoOp
{
    public class TipoDocumentoOperations:ITipoDocumentoOperations
    {
        private readonly bloodbog_bdEntities _context;
        public TipoDocumentoOperations(bloodbog_bdEntities context)
        {
            this._context = context;
            this._context.Configuration.ProxyCreationEnabled = false;
        }
        public List<Tipo_Documento> getAll()
        {
            return _context.Tipo_Documento.ToList();
        }

    }
}
