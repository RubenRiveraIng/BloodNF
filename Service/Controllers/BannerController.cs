using BusinessLogic.Banner;
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
    [RoutePrefix("api/banner")]

    public class BannerController : ApiController
    {
        private readonly BusinessLogic.Banner.Banner _operations;

        public BannerController()
        {
            this._operations = new BusinessLogic.Banner.Banner(new bloodbog_bdEntities());
        }

        [HttpGet]
        [Route("getBanner")]
        public dynamic getBanner()
        {

            try
            {
                return Ok(_operations.getBanner());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        
        } 

    }
}
