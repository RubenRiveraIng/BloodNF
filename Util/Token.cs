using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Token;
using System.Security.Claims;

namespace Util
{
    public static class Token
    {
        public static string Generate(string key,string audienceToken,string issuerToken, string expireTime, Claims dataClaims)
        {
            // appsetting for Token JWT
            //var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            //var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            //var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            //var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            { new Claim(ClaimTypes.Name, dataClaims.userId.ToString()),
              new Claim(ClaimTypes.Role, dataClaims.userRole) 
            });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}
