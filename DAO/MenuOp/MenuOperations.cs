using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO.MenuOp
{
    public class MenuOperations: IMenuOperations
    {
        private readonly bloodbog_bdEntities _context;
        public MenuOperations(bloodbog_bdEntities context)
        {
            this._context = context;
            this._context.Configuration.ProxyCreationEnabled = false;
        }
        public List<Menu> getMenus(int IdRol)
        {
            return (from m in _context.Menu
                   join mr in _context.Menu_Rol on m.IdMenu equals mr.IdMenu
                   where mr.IdRol == IdRol
                   select m).ToList();
                   //db.A.Include("B").Where(x =>x.Id==3
        }
    }
}
