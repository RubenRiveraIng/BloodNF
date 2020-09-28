using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.MenuOp
{
    public interface IMenuOperations
    {
        List<Menu> getMenus(int IdRol);
    }
}
