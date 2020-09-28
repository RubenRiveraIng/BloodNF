using BusinessLogic.LineasAtencion;
using DAO;
using System;
using Newtonsoft.Json;
using System.Web.Http;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Http.Cors;

namespace Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/LineasAtencion")]
    public class LineasAtencionController : ApiController
    {
        private readonly LineasAtencion _operations;

        public LineasAtencionController()
        {
            this._operations = new LineasAtencion((new bloodbog_bdEntities()));
        }

        [HttpGet]
        [Route("getLineasAtencion")]

        public dynamic GetLineasAtencion()
        {
            try
            {
                return Ok(_operations.getLineas_Atencion());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
