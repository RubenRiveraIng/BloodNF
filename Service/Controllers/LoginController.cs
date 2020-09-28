using BusinessLogic.Usuario;
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
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private readonly BusinessLogic.Usuario.Usuario _operations;
        private List<string> dataToken;
        public LoginController()
        {
            this._operations = new BusinessLogic.Usuario.Usuario(new bloodbog_bdEntities());
            dataToken = new List<string>();
            dataToken.Add(ConfigurationManager.AppSettings["JWT_SECRET_KEY"]);
            dataToken.Add(ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"]);
            dataToken.Add(ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"]);
            dataToken.Add(ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"]);
        }
        [HttpPost]
        [Route("validateUser")]
        public dynamic validateUser(DAO.Usuario usuario)
        {
            try
            {
                return Ok(_operations.validateUser(dataToken, usuario));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("create")]
        public dynamic create(DAO.Usuario usuario)
        {
            try
            {
                return Ok(_operations.create(usuario));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
