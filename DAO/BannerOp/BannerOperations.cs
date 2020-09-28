using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO.BannerOp
{
    public class BannerOperations : IBannerOperations
    {
        private readonly bloodbog_bdEntities _context;
        public BannerOperations(bloodbog_bdEntities context)
        {
            this._context = context;
            this._context.Configuration.ProxyCreationEnabled = false;
        }
        public List<Banner> getBanner()
        {
            return _context.Banner.Where(
                B => B.Fecha_Hasta >= DateTime.Now
                ).ToList();
        }
    }
}