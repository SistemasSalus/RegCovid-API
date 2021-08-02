using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BE
{
    public class UsuarioRegcovidBE
    {
        public int i_UsuarioRegcovidId { get; set; }
        public int i_NodeId { get; set; }
        public string v_OrganizationId { get; set; }
        public string v_ProtocolId { get; set; }
        public string v_NodeName { get; set; }
        public string v_UserName { get; set; }
        public string v_Password { get; set; }
        public string i_IsDeleted { get; set; }

        
    }

    public class UsuarioRecovidRequestLogin
    {
        public int NodeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }

    public class UsuarioRecovidResponseLogin
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
