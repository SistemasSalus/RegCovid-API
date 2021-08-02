using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Security.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SALUS.REGCOVID.API.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("auth/login/")]
        public IHttpActionResult Login(LoginRequest login)
        {
            var oAuthorizationBL = new AuthorizationBL();

            var userRegCovid =
            oAuthorizationBL.Login(new LoginRequest
            {
                UserName = login.UserName,
                Password = login.Password,
                NodeId = login.NodeId
            });

            var token = TokenGenerator.GenerateTokenJwt(userRegCovid.UsuarioRegcovidId.ToString(), userRegCovid.NodeId.ToString(), userRegCovid.NodeName, userRegCovid.UserName, userRegCovid.OrganizationId, userRegCovid.ProtocolId);
            userRegCovid.jwt = token;
            userRegCovid.refreshToken = token;
            return Ok(userRegCovid);
        }
    }
}
