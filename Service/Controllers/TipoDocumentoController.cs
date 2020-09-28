using BusinessLogic.TipoDocumento;
using DAO;
using System;
using Newtonsoft.Json;
using System.Web.Http;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Http.Cors;
using System.Net.Http;

namespace Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    [RoutePrefix("api/TipoDocumento")]
    
    public class TipoDocumentoController : ApiController
    {
        private readonly TipoDocumento _operations;
        public TipoDocumentoController()
        { 
            this._operations = new TipoDocumento(new bloodbog_bdEntities());
        }
        [HttpGet]
        [Route("getTipoDocumento")]
        public dynamic getTipoDocumento()
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
