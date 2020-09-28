using BusinessLogic.CampanasDonacion;
using DAO;
using System;
using Newtonsoft.Json;
using System.Web.Http;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Http.Cors;
using System.Security.Claims;
using System.Threading;
using System.Linq;

namespace Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/campanasdoncacion")]
    public class CampanasDonacionController : ApiController

    {
        private readonly CampanasDonacion _operations;
        public dynamic idUserClaim;
        public CampanasDonacionController()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            this._operations = new CampanasDonacion(new bloodbog_bdEntities());
            idUserClaim = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                             .Select(c => c.Value).SingleOrDefault();
        }


        [HttpGet]
        [Route("getCampanasDonacion")]

        public dynamic GetCampanaDonacion()
        {
            try
            {
                return Ok(_operations.getCampanasDonacion());
            }
            catch (Exception ex)
            { 
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getCampanasDonacionById")]
        public dynamic getCampanaDonacionById(int Id)
        {
            try
            {
                return Ok(_operations.getCampañaDonacionById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createCampana")]
        public dynamic createCampana (Campanas_Donacion data)
        {
            try
            {
                return Ok(_operations.createCamapanaDonacion(data,Convert.ToInt32(idUserClaim)));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
