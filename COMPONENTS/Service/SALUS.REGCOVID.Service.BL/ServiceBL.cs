using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Service.DA;
using System.Collections.Generic;
using static SALUS.REGCOVID.Common.Resource.Enums;

namespace SALUS.REGCOVID.Service.BL
{
    public class ServiceBL
    {
        private ServiceDA _serviceDA = null;

        public ServiceBL()
        {
            _serviceDA = new ServiceDA();
        }

        public List<ServiceResponse> GetServices(ServiceRequest oServiceRequest)
        {
            if (oServiceRequest.Status == (int)ServiceStatus.Pending) //PENDIENTE
            {
                return _serviceDA.GetServices(oServiceRequest).FindAll(p=> p.EncuestaCulminada == null || p.LaboratorioCulminada == null);
            }
            else if (oServiceRequest.Status == (int)ServiceStatus.Completed) //CULMINADO
            {
                return _serviceDA.GetServices(oServiceRequest).FindAll(p => p.EncuestaCulminada == (int)ExamStatus.Completed && p.LaboratorioCulminada == (int)ExamStatus.Completed);
            }
            else
            {
                return _serviceDA.GetServices(oServiceRequest);
            }
        }

        public List<ServiceResponse> GetServicesForAdmin(ServiceRequestForAdmin oServiceRequest)
        {
            return _serviceDA.GetServicesForAdmin(oServiceRequest);
         
        }

        public List<IndicadoresResponse> ServicesIndicators(string node, string dateService)
        {
            return _serviceDA.ServicesIndicators(node, dateService);
        }

        public bool UpdateStatusToDeletedsService(string serviceId)
        {
            return _serviceDA.UpdateStatusToDeletedsService(serviceId);
        }
    }
}
