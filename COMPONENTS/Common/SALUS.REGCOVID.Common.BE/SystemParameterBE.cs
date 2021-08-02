using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BE
{
    public class SystemParameterRequest
    {
        public int GroupId { get; set; }
    }

    public class SystemParameterResponse
    {
        public int ParameterId { get; set; }
        public string Value1 { get; set; }
    }
}
