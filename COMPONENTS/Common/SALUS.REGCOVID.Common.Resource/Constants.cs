using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.Resource
{
    public class Constants
    {
        public const string CONEXION_NAME = "ConexionDB";
        public const string CONFIGURATION_FILE_PATH_SYSTEM = @"SystemConfiguration\System.xml";
        public const string MANAGEMENT_SYSTEM = "ManagementSystem";
        public const string SYSTEM_CONFIGURATION = "SystemConfiguration";
        public const string GENERAL = "General";


        #region Prueba Rápida

        public static string PR_ID = "N003-ME000000060";
        public static string PR_DOMICILIO_ID = "N006-MF000000045";
        public static string PR_GEOLOCALIZACION_ID = "N006-MF000000046";
        public static string PR_PROFESION_ID = "N006-MF000000047";
        public static string PR_ES_PERSONAL_SALUD_ID = "N006-MF000000048";
        public static string PR_TIENE_SINTOMAS_ID = "N006-MF000000049";
        public static string PR_INICIO_SINTOMAS_ID = "N006-MF000000050";
        public static string PR_CEFALEA_ID = "N006-MF000000051";
        public static string PR_CONGESTION_NASAL_ID = "N006-MF000000052";
        public static string PR_DIARREA_ID = "N006-MF000000053";
        public static string PR_DIFIC_RESPIRA_ID = "N006-MF000000054";
        public static string PR_DOLOR_ID = "N006-MF000000055";
        public static string PR_DOLOR_GARGANTA_ID = "N006-MF000000056";
        public static string PR_FIEBRE_ESCALOFRIO_ID = "N006-MF000000057";
        public static string PR_IRRITABILIDAD_ID = "N006-MF000000058";
        public static string PR_MALESTAR_GENERAL_ID = "N006-MF000000059";
        public static string PR_NAUSEAS_ID = "N006-MF000000060";
        public static string PR_OTROS_ID = "N006-MF000000061";
        public static string PR_TOS_ID = "N006-MF000000062";
        public static string PR_ABDOMINAL_ID = "N006-MF000000063";
        public static string PR_ARTICULACIONES_ID = "N006-MF000000064";
        public static string PR_MUSCULAR_ID = "N006-MF000000065";
        public static string PR_PECHO_ID = "N006-MF000000066";
        public static string PR_OTROS_SINTOMAS_ID = "N006-MF000000067";
        public static string PR_CLASIFICACION_CLINICA_ID = "N006-MF000000068";
        public static string PR_FECHA_EJECUCION_ID = "N006-MF000000069";
        public static string PR_PROCEDENCIA_SOLICITUD_ID = "N006-MF000000070";
        public static string PR_RES_1_PRUEBA_ID = "N006-MF000000071";
        public static string PR_RES_2_PRUEBA_ID = "N006-MF000000072";
        public static string PR_ASMA_ID = "N006-MF000000073";
        public static string PR_CANCER_ID = "N006-MF000000074";
        public static string PR_DIABETES_ID = "N006-MF000000075";
        public static string PR_EMBARAZO_ID = "N006-MF000000076";
        public static string PR_ENF_CARDIO_ID = "N006-MF000000077";
        public static string PR_INMUNOSUPRESOR_ID = "N006-MF000000078";
        public static string PR_ENF_PULMONAR_ID = "N006-MF000000079";
        public static string PR_HIPERTENCION_ARTERIAL_ID = "N006-MF000000080";
        public static string PR_INSUFICIENCIA_RENAL_ID = "N006-MF000000081";
        public static string PR_MAYOR_60_ID = "N006-MF000000082";
        public static string PR_OBESIDAD_ID = "N006-MF000000083";
        public static string PR_PERSONAL_SALUD_ID = "N006-MF000000084";


        public static string ANTIGENO_ID = "N003-ME000000067";
        public static string ANTIGENO_DOMICILIO_ID = "N006-MF000000225";
        public static string ANTIGENO_GEOLOCALIZACION_ID = "N006-MF000000226";
        public static string ANTIGENO_PROFESION_ID = "N006-MF000000227";
        public static string ANTIGENO_ES_PERSONAL_SALUD_ID = "N006-MF000000228";
        public static string ANTIGENO_TIENE_SINTOMAS_ID = "N006-MF000000229";
        public static string ANTIGENO_INICIO_SINTOMAS_ID = "N006-MF000000230";
        public static string ANTIGENO_CEFALEA_ID = "N006-MF000000231";
        public static string ANTIGENO_CONGESTION_NASAL_ID = "N006-MF000000232";
        public static string ANTIGENO_DIARREA_ID = "N006-MF000000233";
        public static string ANTIGENO_DIFIC_RESPIRA_ID = "N006-MF0000000234";
        public static string ANTIGENO_DOLOR_ID = "N006-MF000000235";
        public static string ANTIGENO_DOLOR_GARGANTA_ID = "N006-MF000000236";
        public static string ANTIGENO_FIEBRE_ESCALOFRIO_ID = "N006-MF000000238";
        public static string ANTIGENO_IRRITABILIDAD_ID = "N006-MF000000239";
        public static string ANTIGENO_MALESTAR_GENERAL_ID = "N006-MF000000240";
        public static string ANTIGENO_NAUSEAS_ID = "N006-MF000000241";
        public static string ANTIGENO_TOS_ID = "N006-MF000000242";
        public static string ANTIGENO_ABDOMINAL_ID = "N006-MF000000243";
        public static string ANTIGENO_ARTICULACIONES_ID = "N006-MF000000244";
        public static string ANTIGENO_MUSCULAR_ID = "N006-MF000000245";
        public static string ANTIGENO_PECHO_ID = "N006-MF000000246";
        public static string ANTIGENO_OTROS_SINTOMAS_ID = "N006-MF000000247";
        public static string ANTIGENO_CLASIFICACION_CLINICA_ID = "N006-MF000000248";
        public static string ANTIGENO_FECHA_EJECUCION_ID = "N006-MF000000249";
        public static string ANTIGENO_PROCEDENCIA_SOLICITUD_ID = "N006-MF000000250";
        public static string ANTIGENO_RES_1_PRUEBA_ID = "N006-MF000000251";
        public static string ANTIGENO_RES_2_PRUEBA_ID = "N006-MF000000252";
        public static string ANTIGENO_ASMA_ID = "N006-MF000000253";
        public static string ANTIGENO_CANCER_ID = "N006-MF000000254";
        public static string ANTIGENO_DIABETES_ID = "N006-MF000000255";
        public static string ANTIGENO_EMBARAZO_ID = "N006-MF000000256";
        public static string ANTIGENO_ENF_CARDIO_ID = "N006-MF000000257";
        public static string ANTIGENO_INMUNOSUPRESOR_ID = "N006-MF000000258";
        public static string ANTIGENO_ENF_PULMONAR_ID = "N006-MF000000259";
        public static string ANTIGENO_HIPERTENCION_ARTERIAL_ID = "N006-MF000000260";
        public static string ANTIGENO_INSUFICIENCIA_RENAL_ID = "N006-MF000000261";
        public static string ANTIGENO_MAYOR_60_ID = "N006-MF000000262";
        public static string ANTIGENO_OBESIDAD_ID = "N006-MF000000263";
        public static string ANTIGENO_PERSONAL_SALUD_ID = "N006-MF000000264";
        public static string ANTIGENO_CONTINUIDAD_DE_LA_ATENCION_ID = "N006-MF000000265";
        public static string ANTIGENO_PROCEDIMIENTO_A_SEGUIR_ID = "N006-MF000000266";
        public static string ANTIGENO_OBSERVACION_ID = "N006-MF000000267";

        #endregion
    }
}
