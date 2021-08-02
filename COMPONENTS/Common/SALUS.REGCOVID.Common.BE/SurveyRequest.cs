using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BE
{
    public class SurveyRequest
    {
        public string ServiceComponentId { get; set; }
        public string PersonId { get; set; }
        public string ComponentId { get; set; }
        public string TipoDomicilio { get; set; }
        public string Geolocalizacion { get; set; }
        public string EsPersonalSaludCbo { get; set; }
        public string Profesion { get; set; }
        public string TieneSintomas { get; set; }
        public string InicioSintomas { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Tos { get; set; }
        public string DolorGarganta { get; set; }
        public string CongestionNasal { get; set; }
        public string DificultadRespiratoria { get; set; }
        public string FiebreEscalofrio { get; set; }
        public string MalestarGeneral { get; set; }
        public string Diarrea { get; set; }
        public string NauseasVomitos { get; set; }
        public string Cefalea { get; set; }
        public string IrritabilidadConfusion { get; set; }
        public string Dolor { get; set; }
        public string Expectoracion { get; set; }
        public string DolorMuscular { get; set; }
        public string DolorAbdominal { get; set; }
        public string DolorPecho { get; set; }
        public string DolorArticulaciones { get; set; }
        public string OtrosSintomas { get; set; }
        public string Diabetes { get; set; }
        public string EnfPulmonarCronica { get; set; }
        public string Cancer { get; set; }
        public string HipertensionArterial { get; set; }
        public string Obesidad { get; set; }
        public string Mayor65 { get; set; }
        public string InsuficienciaCronica { get; set; }
        public string Embarazo { get; set; }
        public string EnfCardiovascular { get; set; }
        public string Asma { get; set; }
        public string EnfInmunosupresor { get; set; }
        public string PersonalSalud { get; set; }
    }
}
