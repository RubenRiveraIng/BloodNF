using BusinessLogic.ClinicasBancosSangre;
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
    [RoutePrefix("api/clinicasbancos")]
    public class ClinicasBancosSangreController : ApiController
    {
        private readonly ClinicasBancosSangre _operations;
        public ClinicasBancosSangreController()
        {
            this._operations = new ClinicasBancosSangre(new bloodbog_bdEntities());
        }
        [HttpGet]
        [Route("getClinicasBancosSangre")]

        public dynamic getClinicasBanosSangre()
        {
            try
            {
                return Ok(_operations.getClinicasBancosSangre());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
