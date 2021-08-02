using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Schedule.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Schedule.BL
{
    public class ScheduleBL
    {
        private ScheduleDA _scheduleDA = null;

        public ScheduleBL()
        {
            _scheduleDA = new ScheduleDA();
        }

        public string ScheduleWorkerRegCovid(ScheduleRegcovidRequest oScheduleRegcovidRequest)
        {
            //var organization = _scheduleDA.GetOrganizationFact(oScheduleRegcovidRequest.UserId);
            var protocol = _scheduleDA.GetProtocolIdForSchedule(oScheduleRegcovidRequest.OrganizationId, oScheduleRegcovidRequest.ComponentId);
            if (string.IsNullOrEmpty(protocol.ProtocolId))            
                return "FAIL";
            
            return _scheduleDA.ScheduleWorkerRegCovid(oScheduleRegcovidRequest, protocol.ProtocolId);
        }
    }
}
