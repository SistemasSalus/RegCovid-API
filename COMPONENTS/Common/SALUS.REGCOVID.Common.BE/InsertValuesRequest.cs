using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BE
{
    public class InsertValuesRequest
    {
        public string ServiceComponentId { get; set; }
        public string ComponentFieldId { get; set; }
        public string Value1 { get; set; }
        public int InsertUserId { get; set; }
    }

    public class UpdateValuesRequest
    {
        public string ServiceComponentFieldValuesId { get; set; }        
        public string Value1 { get; set; }
        public int UpdateUserId { get; set; }
    }
}
