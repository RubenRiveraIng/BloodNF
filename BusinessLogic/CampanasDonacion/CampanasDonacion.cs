using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DAO.CampanasDonacionOp;


namespace BusinessLogic.CampanasDonacion
{
    public class CampanasDonacion
    {
        private ICampanasDonacionOperations _operations;
        public CampanasDonacion(bloodbog_bdEntities context)
        {
            this._operations = new CampanasDonacionOperations(context);
        }

        public dynamic getCampanasDonacion()
        {
            return _operations.getCampañaDonacion();
        }

        public dynamic getCampañaDonacionById(int Id)
        {
            return _operations.getCampañaDonacionById(Id);
        }

        public dynamic createCamapanaDonacion(Campanas_Donacion data,int idUsuario)
        {
            data.IdUsuario = idUsuario;
            return _operations.createCamapanaDonacion(data);
        }
    }
}
