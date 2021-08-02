using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BE
{

    public class ServiceRequest
    {
        public string FechaServicio { get; set; }
        public int? MedicalCenter { get; set; }
        public int Status { get; set; }
        public string ComponentId { get; set; }
        public string OrganizationId { get; set; }
        public string NodeId { get; set; }
        public string UserName { get; set; }
    }

    public class ServiceRequestForAdmin
    {
        public string FechaInicioServicio { get; set; }
        public string FechaFinServicio { get; set; }
        public string NameOrDocument { get; set; }
        
    }

    public class ServiceOtherClinicsRequest
    {
        public string OrganizationId { get; set; }
        public string NodeId { get; set; }
        public string Fecha { get; set; }
    }

    public class ServiceResponse
    {
        public DateTime d_ServiceDate { get; set; }
        public string WorkerName { get; set; }
        public string ProtocolName { get; set; }
        public string OrganizationName { get; set; }
        public string CurrentOccupation { get; set; }
        public string ServiceId { get; set; }
        public string PersonId { get; set; }
        public string ComponentId { get; set; }
        public string ServiceComponentId { get; set; }
        public int IIndex { get; set; }
        public string OrganizationId { get; set; }
        public string TelephoneNumber { get; set; }
        public int? EncuestaCulminada { get; set; }
        public int? LaboratorioCulminada { get; set; }
        public int ClinicaExternad { get; set; }
        public string MedicalCenter { get; set; }
        public string TypeExam { get; set; }
    }


    public class IndicadoresResponse
    {
        public string Resultado { get; set; }
        public int Contador { get; set; }
        public int Total { get; set; }
    }
}
