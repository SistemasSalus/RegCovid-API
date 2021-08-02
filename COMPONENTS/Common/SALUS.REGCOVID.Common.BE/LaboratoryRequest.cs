
namespace SALUS.REGCOVID.Common.BE
{
    public class LaboratoryRequest
    {
        public string ServiceComponentId { get; set; }
        public string PersonId { get; set; }
        public string ComponentId { get; set; }
        public string FechaEjecucion { get; set; }
        public string ProcedenciaSolicitud { get; set; }
        public string ResultadoPrimeraPrueba { get; set; }
        public string ResultadoSegundaPrueba { get; set; }
        public string ClasificacionClinica { get; set; }
        public string ConfirmeResultado { get; set; }
    }
}
