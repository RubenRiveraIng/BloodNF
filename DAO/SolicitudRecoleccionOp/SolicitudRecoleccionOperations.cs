using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO.SolicitudRecoleccionOp
{
    public class SolicitudRecoleccionOperations : ISolicitudRecoleccionOperations
    {
        private readonly bloodbog_bdEntities _context;
        public SolicitudRecoleccionOperations(bloodbog_bdEntities context)
        {
            this._context = context;
            this._context.Configuration.ProxyCreationEnabled = false;
        }
        public List<JoinSolicitud> getSolicitudesPorUsuarioRegular(int IdUsuario)
        {
            var query = from s in _context.Solicitud_Recoleccion
                        join us in _context.Usuario on s.IdUsuario_Recolecta equals us.IdUsuario
                        join e in _context.Estado_Solicitud on s.IdEstado_Solicitud equals e.IdEstado_Solicitud
                        where (s.IdUsuario_Solicita == IdUsuario)
                        orderby (s.Fecha_Recoleccion)
                        select new JoinSolicitud
                        {
                            NombreEntidad = us.Nombres + " " + us.PrimerApellido + " " + us.SegundoApellido,
                            Direccion = s.Direccion_Donde,
                            Fecha_Recoleccion = s.Fecha_Recoleccion,
                            IdSolicitud = s.IdSolicitud,
                            NombreSolicitante = null,
                            IdEstado_Solicitud=s.IdEstado_Solicitud,
                            strEstado_Solicitud =e.Nombre,
                            LNG=s.LGN_Donde,
                            LTD=s.LTD_Donde
                        };


                return query.ToList();
        }
        public List<JoinSolicitud> getSolicitudPorUsuarioEntidad(int IdUsuario)
        {
            var query = from s in _context.Solicitud_Recoleccion
                        join us in _context.Usuario on s.IdUsuario_Solicita equals us.IdUsuario
                        join e in _context.Estado_Solicitud on s.IdEstado_Solicitud equals e.IdEstado_Solicitud
                        where (s.IdUsuario_Recolecta == IdUsuario)
                        orderby (s.Fecha_Recoleccion)
                        select new JoinSolicitud
                        {
                            NombreEntidad =null ,
                            Direccion = s.Direccion_Donde,
                            Fecha_Recoleccion = s.Fecha_Recoleccion,
                            IdSolicitud = s.IdSolicitud,
                            NombreSolicitante = us.Nombres + " " + us.PrimerApellido + " " + us.SegundoApellido,
                            IdEstado_Solicitud = s.IdEstado_Solicitud,
                            strEstado_Solicitud = e.Nombre,
                            LNG = s.LGN_Donde,
                            LTD = s.LTD_Donde
                        };


            return query.ToList();
        }

        public int createSolicitudRecoleccion (Solicitud_Recoleccion data)
        {
             _context.Solicitud_Recoleccion.Add(data);
            return _context.SaveChanges();
        }
        public List<JoinSolicitud> getSolicitudPorUsuarioEntidadById(int IdSolicitud)
        {
            var query = from s in _context.Solicitud_Recoleccion
                        join us in _context.Usuario on s.IdUsuario_Solicita equals us.IdUsuario
                        join e in _context.Estado_Solicitud on s.IdEstado_Solicitud equals e.IdEstado_Solicitud
                        where (s.IdSolicitud == IdSolicitud)
                        orderby (s.Fecha_Recoleccion)
                        select new JoinSolicitud
                        {
                            NombreEntidad = null,
                            Direccion = s.Direccion_Donde,
                            Fecha_Recoleccion = s.Fecha_Recoleccion,
                            IdSolicitud = s.IdSolicitud,
                            NombreSolicitante = us.Nombres + " " + us.PrimerApellido + " " + us.SegundoApellido,
                            IdEstado_Solicitud = s.IdEstado_Solicitud,
                            strEstado_Solicitud = e.Nombre,
                            LNG = s.LGN_Donde,
                            LTD = s.LTD_Donde
                        };


            return query.ToList();
        }
    }
}
