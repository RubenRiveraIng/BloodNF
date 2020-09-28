using System;
using System.Collections.Generic;
using System.Linq;
namespace DAO.CampanasDonacionOp
{
    public class CampanasDonacionOperations: ICampanasDonacionOperations
    {
        private readonly bloodbog_bdEntities _context;

        public CampanasDonacionOperations(bloodbog_bdEntities context)
        {
            this._context = context;
            this._context.Configuration.ProxyCreationEnabled = false;
        }
        public List<Campanas_Donacion> getCampañaDonacion()
        {
            return _context.Campanas_Donacion
                .Where(
                C => C.Fecha_Fin >= DateTime.Now
                )
                .ToList();
        }

        public List<Campanas_Donacion> getCampañaDonacionById(int Id)
        {
            return _context.Campanas_Donacion
                .Where(
                C => C.IdCampanas_Donacion == Id
                )
                .ToList();
        }

        public int createCamapanaDonacion(Campanas_Donacion data)
        {
            _context.Campanas_Donacion.Add(data);
            return _context.SaveChanges();
        }

    }
}
