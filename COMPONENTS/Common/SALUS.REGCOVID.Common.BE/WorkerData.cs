using System;

namespace SALUS.REGCOVID.Common.BE
{
    public class WorkerDataRequest
    {
        public string Filtro { get; set; }
    }

    public class WorkerDataResponse
    {
        public string Filtro { get; set; }
        public string OrganizationId { get; set; }
        public int HcId { get; set; }
        public int HcActualizadoId { get; set; }
        public string HC { get; set; }
        public int HCId { get; set; }
        public string EmpresaEmpleadora { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Dni { get; set; }
        public string Sexo { get; set; }
        public int SexoId { get; set; }
        public int SedeId { get; set; }
        public string Sede { get; set; }
        public string Puesto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
