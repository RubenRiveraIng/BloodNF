using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DAO.MenuOp;
namespace BusinessLogic.Menu
{
    public class Menu
    {
        private IMenuOperations _operations;

        public Menu(bloodbog_bdEntities context)
        {
            this._operations = new MenuOperations(context);
        }
        public List<DAO.Menu> getMenus(int IdRol)
        {
            return _operations.getMenus(IdRol);
        }
    }
}
