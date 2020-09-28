using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/solicitudrecoleccion")]
    public class SolicitudReconleccionController : ApiController
    {

        private readonly BusinessLogic.SolicitudRecoleccion.SolicitudRecoleccion _operations;
        public dynamic idUserClaim;
        public SolicitudReconleccionController()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            this._operations = new BusinessLogic.SolicitudRecoleccion.SolicitudRecoleccion(new bloodbog_bdEntities());
            idUserClaim = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                       .Select(c => c.Value).SingleOrDefault();
        }


        [HttpGet]
        [Route("getSolicitudesPorUsuarioRegular")]
        public dynamic getSolicitudesPorUsuarioRegular()
        {

            try
            {
                return Ok(_operations.getSolicitudesPorUsuarioRegular(Convert.ToInt32(idUserClaim)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("getSolicitudPorUsuarioEntidad")]
        public dynamic getSolicitudPorUsuarioEntidad()
        {

            try
            {
                return Ok(_operations.getSolicitudPorUsuarioEntidad(Convert.ToInt32(idUserClaim)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("createSolicitudRecoleccion")]
        public dynamic createSolicitudRecoleccion(Solicitud_Recoleccion data)
        {

            try
            {
                return Ok(_operations.createSolicitudRecoleccion(data, Convert.ToInt32(idUserClaim)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.InnerException.Message);
            }

        }
        [HttpGet]
        [Route("getSolicitudPorUsuarioEntidadById")]
        public dynamic getSolicitudPorUsuarioEntidadById(int IdSolicitud)
        {

            try
            {
                return Ok(_operations.getSolicitudPorUsuarioEntidadById(IdSolicitud));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}