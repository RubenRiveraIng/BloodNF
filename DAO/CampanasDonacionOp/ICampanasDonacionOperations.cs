using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.CampanasDonacionOp
{
    public interface ICampanasDonacionOperations
    {
        List<Campanas_Donacion> getCampañaDonacion();
        List<Campanas_Donacion> getCampañaDonacionById(int Id);
        int createCamapanaDonacion(Campanas_Donacion data);
    }
}
