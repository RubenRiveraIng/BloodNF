using BusinessLogic.Usuario;
using DAO;
using System;
using Newtonsoft.Json;
using System.Web.Http;
using System.Configuration;
using System.Collections.Generic;
using Model.Email;
using System.Web.Http.Cors;
using System.Security.Claims;
using System.Threading;
using System.Linq;

namespace Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly BusinessLogic.Usuario.Usuario _operations;
        private List<string> dataToken;
        public dynamic idUserClaim;
        public UsuarioController()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            this._operations = new BusinessLogic.Usuario.Usuario(new bloodbog_bdEntities());
            dataToken = new List<string>();
            dataToken.Add(ConfigurationManager.AppSettings["JWT_SECRET_KEY"]);
            dataToken.Add(ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"]);
            dataToken.Add(ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"]);
            dataToken.Add(ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"]);
            idUserClaim = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                               .Select(c => c.Value).SingleOrDefault();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("resetPassword")]
        public dynamic resetPassword(string numDocumento, int tipoDocumento)
        {
            try
            {
                SendMail dataEmail = new SendMail();
                dataEmail.emailFrom = ConfigurationManager.AppSettings["emailFrom"];
                dataEmail.nameFrom = ConfigurationManager.AppSettings["nameFrom"];
                dataEmail.subject = ConfigurationManager.AppSettings["subject"];
                dataEmail.smtpAddress = ConfigurationManager.AppSettings["smtpAddress"];
                dataEmail.smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
                dataEmail.emailUserAuth = ConfigurationManager.AppSettings["emailUserAuth"];
                dataEmail.passUserAuth = ConfigurationManager.AppSettings["passUserAuth"];
                return Ok(_operations.sendMailResetPassword(
                                       ConfigurationManager.AppSettings["environmentUrl"],
                                       dataToken,
                                      numDocumento,
                                      tipoDocumento,
                                      dataEmail));
            }
            catch (Exception ex)
            {
                return BadRequest("CC:"+ numDocumento+"tipo:"+ tipoDocumento + ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("updatePassword")]
        public dynamic updatePassword(string password)
        {
            try
            {
                return Ok(_operations.updatePassword(Convert.ToInt32(idUserClaim), password));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("updateUser")]
        public dynamic updateUser(DAO.Usuario usuario)
        {
            try
            {
                return Ok(_operations.updateUser(Convert.ToInt32(idUserClaim), usuario));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("getUsuario")]
        public dynamic getUsuario()
        {
            try
            {
                return Ok(_operations.getUsuarioById(Convert.ToInt32(idUserClaim)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("getEntidades")]
        public dynamic getEntidades()
        {
            try 
            {
                return Ok(_operations.getEntidades());
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
