using BusinessLogic.TipoSangre;
using DAO;
using System;
using Newtonsoft.Json;
using System.Web.Http;
using System.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Web.Http.Cors;

namespace Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    [RoutePrefix("api/TipoSangre")]
    public class TipoSangreController : ApiController
    {
        private readonly TipoSangre _operations;
        public TipoSangreController()
        {
            this._operations = new TipoSangre(new bloodbog_bdEntities());
        }
        [HttpGet]
        [Route("getTipoSangre")]
        public dynamic getTipoSangre()
        {
            try
            {
                return Ok(_operations.getAll());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
