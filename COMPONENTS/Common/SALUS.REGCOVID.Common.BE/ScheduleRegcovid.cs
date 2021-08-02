using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BE
{
    public class ScheduleRegcovidRequest
    {
        public int NodeId { get; set; }
        public string OrganizationId { get; set; }
        public string SedeId { get; set; }
        public string ComponentId { get; set; }
        public string FirstName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public int DocTypeId { get; set; }
        public string DocNumber { get; set; }
        public int SexTypeId { get; set; }
        public string Birthdate { get; set; }
        public string Mail { get; set; }
        public string TelephoneNumber { get; set; }
        public string CurrentOccupation { get; set; }
        public string AdressLocation { get; set; }
        public string NombreSede { get; set; }
        public int TipoEmpresaCovidId { get; set; }
        public int UserId { get; set; }
        public string Tecnico { get; set; }
        public int ClinicaExternad { get; set; }
        public DateTime? FechaExamen { get; set; }
        public string EmpresaEmpleadora { get; set; }
        public int ReasonExamId { get; set; }
        public int PlaceExamId { get; set; }
    }

    public class ProtocolResponse
    {
        public string ProtocolId { get; set; }
    }

    public class OrganizationFact
    {
        public string OrganizationId { get; set; }
    }
}
