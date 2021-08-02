using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BL
{
    public class NodesRegCovidBL
    {
        private NodesRegCovidDA _NodesRegCovidDA = null;

        public NodesRegCovidBL()
        {
            _NodesRegCovidDA = new NodesRegCovidDA();
        }

        public List<NodeRegcovidResponse> GetNodesRegcovid()
        {
            return _NodesRegCovidDA.GetNodesRegcovid();
        }
    }
}
