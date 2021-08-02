using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Security.BL
{
    public class AuthorizationBL
    {
        private AuthorizationDA _authorizationDA = null;

        public AuthorizationBL()
        {
            _authorizationDA = new AuthorizationDA();
        }

        public LoginResponse Login(LoginRequest oLoginRequest)
        {
            return _authorizationDA.LoginUserCovid(oLoginRequest);
        }
    }
}
