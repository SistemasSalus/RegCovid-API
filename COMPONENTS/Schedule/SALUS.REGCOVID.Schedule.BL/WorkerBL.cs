using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Schedule.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Schedule.BL
{
    public class WorkerBL
    {
        private WorkerDA _workerDA = null;

        public WorkerBL()
        {
            _workerDA = new WorkerDA();
        }

        public List<WorkerDataResponse> GetDataWorker(WorkerDataRequest oHcActualizadoRequest)
        {
            return _workerDA.GetDataWorker(oHcActualizadoRequest);
        }
    }
}
