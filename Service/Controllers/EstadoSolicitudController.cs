using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessLogic.EstadoSolicitud;
using DAO;
namespace Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/estadosolicitud")]
    public class EstadoSolicitudController : ApiController
    {
        private readonly EstadoSolicitud _operations;

        public EstadoSolicitudController()
        {
            this._operations = new EstadoSolicitud(new bloodbog_bdEntities());
        }


        [HttpGet]
        [Route("getEstadoSolicitud")]

        public dynamic getEstadoSolicitud()
        {
            try
            {
                return Ok(_operations.getEstadoSolicitud());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}