using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BL
{
    public class LocationBL
    {
        private LocationDA _locationDA = null;

        public LocationBL()
        {
            _locationDA = new LocationDA();
        }

        public List<SedeResponse> GetLocations(string organizationId)
        {
            return _locationDA.GetLocations(organizationId);
        }

    }
}
