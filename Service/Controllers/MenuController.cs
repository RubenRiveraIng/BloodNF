using BusinessLogic.Menu;
using DAO;
using System;
using Newtonsoft.Json;
using System.Web.Http;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Http.Cors;
using System.Web;
using System.Security.Claims;
using System.Threading;
using System.Linq;

namespace Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/Menu")]

    public class MenuController : ApiController
    {
        private readonly BusinessLogic.Menu.Menu _operations;
        private dynamic rolClaim;

        public MenuController()
        {
            this._operations = new BusinessLogic.Menu.Menu(new bloodbog_bdEntities());
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            rolClaim = identity.Claims.Where(c => c.Type == ClaimTypes.Role)
                               .Select(c => c.Value).SingleOrDefault();
        }

        [HttpGet]
        [Route("getMenus")]
        public dynamic getMenus()
        {

            try
            {
                return Ok(_operations.getMenus(Convert.ToInt32(rolClaim)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
