using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BL
{
    public class PrecioBL
    {
        private PrecioDA _precioDA = null;

        public PrecioBL()
        {
            _precioDA = new PrecioDA();
        }

        public List<Precio> GetPrecios()
        {
            return _precioDA.GetPrecios();
        }

    }
}
