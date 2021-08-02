using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BE
{
    public class LoginRequest
    {
        public int NodeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class LoginResponse
    {
        public int UsuarioRegcovidId { get; set; }

        public string OrganizationId { get; set; }

        public string ProtocolId { get; set; }

        public int NodeId { get; set; }

        public string NodeName { get; set; }

        public string UserName { get; set; }
        public string jwt { get; set; }
        public string refreshToken { get; set; }
    }
}
