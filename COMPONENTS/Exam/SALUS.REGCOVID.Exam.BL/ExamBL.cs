using SALUS.REGCOVID.Common.BE;
using SALUS.REGCOVID.Common.Resource;
using SALUS.REGCOVID.Exam.DA;
using System.Collections.Generic;

namespace SALUS.REGCOVID.Exam.BL
{
    public class ExamBL
    {
        private ExamDA _examDA = null;

        public ExamBL()
        {
            _examDA = new ExamDA();
        }

        public List<ValuesComponentResponse> GetValuesComponent(string serviceId, string componentId)
        {
            return _examDA.GetValuesComponent(serviceId, componentId);
        }

        public bool SaveSurvey(SurveyRequest oSurveyRequest)
        {
            oSurveyRequest.InicioSintomas = FormatFechaInicioSintomas(oSurveyRequest.InicioSintomas);
            var listValues = new List<InsertValuesRequest>();
            //var listValues = oSurveyRequest.ComponentId == Constants.PR_ID ? BuildListSurveyPR(oSurveyRequest) : BuildListSurveyANTIGENO(oSurveyRequest);

            if (oSurveyRequest.ComponentId == Constants.PR_ID)
            {
                listValues = BuildListSurveyPR(oSurveyRequest);
            }
            else if (oSurveyRequest.ComponentId == Constants.ANTIGENO_ID)
            {
                listValues = BuildListSurveyANTIGENO(oSurveyRequest);
            }
            else
            {
                listValues = BuildListSurveyMOLECULAR(oSurveyRequest);
            }

            var valuesDB = _examDA.GetValuesService(oSurveyRequest.ServiceComponentId);
            var campoReferencia = valuesDB.Find(p => p.ComponentFieldId == Constants.PR_DOMICILIO_ID || p.ComponentFieldId == Constants.ANTIGENO_DOMICILIO_ID || p.ComponentFieldId == Constants.MOLECULAR_DOMICILIO_ID);

            if (campoReferencia == null)
            {
                //foreach (var value in listValues)
                //{
                //    value.InsertUserId = 11;
                //    _examDA.InsertValues(value);
                //}

                var result = _examDA.InsertValuesInBlock(listValues);
                if (result)
                {
                    _examDA.CulminateSurvey(oSurveyRequest.ServiceComponentId);
                }

                //_examDA.CulminateSurvey(oSurveyRequest.ServiceComponentId);
            }
            else
            {
                foreach (var value in valuesDB)
                {
                    var oUpdateValuesRequest = new UpdateValuesRequest();
                    oUpdateValuesRequest.ServiceComponentFieldValuesId = value.ServiceComponentFieldValuesId;
                    if (listValues.Find(p => p.ComponentFieldId == value.ComponentFieldId) != null)
                    {
                        oUpdateValuesRequest.Value1 = listValues.Find(p => p.ComponentFieldId == value.ComponentFieldId).Value1;
                        oUpdateValuesRequest.UpdateUserId = 11;
                        _examDA.UpdateValues(oUpdateValuesRequest);
                    }
                }
            }

            return true;

        }

        private string FormatFechaInicioSintomas(string inicioSintomas)
        {
            var arr = inicioSintomas.Split('-');
            if (arr[0] == "null") return "";
            if (arr.Length > 2)
            {
                var day = int.Parse(arr[0]).ToString("D2");
                var month = int.Parse(arr[1]).ToString("D2");
                var year = int.Parse(arr[2]).ToString();

                return day + "-" + month + "-" + year;
            }
            return "";
        }

        public bool SaveLaboratory(LaboratoryRequest oLaboratoryRequest)
        {
            var listValues = new List<InsertValuesRequest>();
            //var listValues = oLaboratoryRequest.ComponentId == Constants.PR_ID ? BuildListLaboratoryPR(oLaboratoryRequest) : BuildListLaboratoryANTIGENO(oLaboratoryRequest);

            if (oLaboratoryRequest.ComponentId == Constants.PR_ID)
            {
                listValues = BuildListLaboratoryPR(oLaboratoryRequest);
            }
            else if (oLaboratoryRequest.ComponentId == Constants.ANTIGENO_ID)
            {
                listValues = BuildListLaboratoryANTIGENO(oLaboratoryRequest);
            }
            else
            {
                listValues = BuildListLaboratoryMOLECULAR(oLaboratoryRequest);
            }

            var valuesDB = _examDA.GetValuesService(oLaboratoryRequest.ServiceComponentId);
            var campoReferencia = valuesDB.Find(p => p.ComponentFieldId == Constants.PR_RES_1_PRUEBA_ID || p.ComponentFieldId == Constants.ANTIGENO_RES_1_PRUEBA_ID || p.ComponentFieldId == Constants.MOLECULAR_RES_1_PRUEBA_ID);

            if (campoReferencia == null)
            {
                //foreach (var value in listValues)
                //{
                //    value.InsertUserId = 11;
                //    _examDA.InsertValues(value);
                //}

                //_examDA.CulminateLaboratory(oLaboratoryRequest.ServiceComponentId);

                var result = _examDA.InsertValuesInBlock(listValues);
                if (result)
                {
                    _examDA.CulminateLaboratory(oLaboratoryRequest.ServiceComponentId);
                }
            }
            else
            {
                foreach (var value in valuesDB)
                {
                    var oUpdateValuesRequest = new UpdateValuesRequest();
                    oUpdateValuesRequest.ServiceComponentFieldValuesId = value.ServiceComponentFieldValuesId;
                    oUpdateValuesRequest.Value1 = listValues.Find(p => p.ComponentFieldId == value.ComponentFieldId).Value1;
                    oUpdateValuesRequest.UpdateUserId = 11;

                    _examDA.UpdateValues(oUpdateValuesRequest);
                }
            }

            return true;

        }

        public List<InsertValuesRequest> BuildListSurveyPR(SurveyRequest oSurveyRequest)
        {
            var list = new List<InsertValuesRequest>();
            var value = new InsertValuesRequest();

            value.ComponentFieldId = Constants.PR_DOMICILIO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.TipoDomicilio;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_GEOLOCALIZACION_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Geolocalizacion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_PROFESION_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Profesion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_ES_PERSONAL_SALUD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EsPersonalSaludCbo;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_TIENE_SINTOMAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.TieneSintomas;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_INICIO_SINTOMAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.InicioSintomas;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_CEFALEA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Cefalea == "false" ? "0" : oSurveyRequest.Cefalea;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_CONGESTION_NASAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.CongestionNasal == "false" ? "0" : oSurveyRequest.CongestionNasal;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_DIARREA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Diarrea == "false" ? "0" : oSurveyRequest.Diarrea;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_DIFIC_RESPIRA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DificultadRespiratoria == "false" ? "0" : oSurveyRequest.DificultadRespiratoria;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_DOLOR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Dolor == "false" ? "0" : oSurveyRequest.Dolor;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_DOLOR_GARGANTA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorGarganta == "false" ? "0" : oSurveyRequest.DolorGarganta;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_FIEBRE_ESCALOFRIO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.FiebreEscalofrio == "false" ? "0" : oSurveyRequest.FiebreEscalofrio;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_IRRITABILIDAD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.IrritabilidadConfusion == "false" ? "0" : oSurveyRequest.IrritabilidadConfusion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_MALESTAR_GENERAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.MalestarGeneral == "false" ? "0" : oSurveyRequest.MalestarGeneral;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_NAUSEAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.NauseasVomitos == "false" ? "0" : oSurveyRequest.NauseasVomitos;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_OTROS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.OtrosSintomas == null ? "" : oSurveyRequest.OtrosSintomas;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_TOS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Tos == "false" ? "0" : oSurveyRequest.Tos;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_ABDOMINAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorAbdominal == "false" ? "0" : oSurveyRequest.DolorAbdominal;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_ARTICULACIONES_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorArticulaciones == "false" ? "0" : oSurveyRequest.DolorArticulaciones;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_MUSCULAR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorMuscular == "false" ? "0" : oSurveyRequest.DolorMuscular;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_PECHO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorPecho == "false" ? "0" : oSurveyRequest.DolorPecho;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_OTROS_SINTOMAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.OtrosSintomas == null ? "" : oSurveyRequest.OtrosSintomas;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_ASMA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Asma == "false" ? "0" : oSurveyRequest.Asma;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_CANCER_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Cancer == "false" ? "0" : oSurveyRequest.Cancer;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_DIABETES_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Diabetes == "false" ? "0" : oSurveyRequest.Diabetes;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_EMBARAZO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Embarazo == "false" ? "0" : oSurveyRequest.Embarazo;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_ENF_CARDIO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EnfCardiovascular == "false" ? "0" : oSurveyRequest.EnfCardiovascular;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_INMUNOSUPRESOR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EnfInmunosupresor == "false" ? "0" : oSurveyRequest.EnfInmunosupresor;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_ENF_PULMONAR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EnfPulmonarCronica == "false" ? "0" : oSurveyRequest.EnfPulmonarCronica;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_HIPERTENCION_ARTERIAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.HipertensionArterial == "false" ? "0" : oSurveyRequest.HipertensionArterial;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_INSUFICIENCIA_RENAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.InsuficienciaCronica == "false" ? "0" : oSurveyRequest.InsuficienciaCronica;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_MAYOR_60_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Mayor65 == "false" ? "0" : oSurveyRequest.Mayor65;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_OBESIDAD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Obesidad == "false" ? "0" : oSurveyRequest.Obesidad;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_PERSONAL_SALUD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.PersonalSalud == "false" ? "0" : oSurveyRequest.PersonalSalud;
            list.Add(value);

            list.Add(value);

            return list;
        }

        public List<InsertValuesRequest> BuildListLaboratoryPR(LaboratoryRequest oLaboratoryRequest)
        {
            var list = new List<InsertValuesRequest>();
            var value = new InsertValuesRequest();

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_CLASIFICACION_CLINICA_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ClasificacionClinica;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_FECHA_EJECUCION_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.FechaEjecucion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_PROCEDENCIA_SOLICITUD_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ProcedenciaSolicitud;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_RES_1_PRUEBA_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ResultadoPrimeraPrueba;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.PR_RES_2_PRUEBA_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ResultadoSegundaPrueba;
            list.Add(value);


            list.Add(value);

            return list;
        }

        public List<InsertValuesRequest> BuildListSurveyANTIGENO(SurveyRequest oSurveyRequest)
        {
            var list = new List<InsertValuesRequest>();
            var value = new InsertValuesRequest();

            value.ComponentFieldId = Constants.ANTIGENO_DOMICILIO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.TipoDomicilio;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_GEOLOCALIZACION_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Geolocalizacion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_PROFESION_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Profesion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_ES_PERSONAL_SALUD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EsPersonalSaludCbo;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_TIENE_SINTOMAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.TieneSintomas;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_INICIO_SINTOMAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.InicioSintomas;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_CEFALEA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Cefalea == "false" ? "0" : oSurveyRequest.Cefalea;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_CONGESTION_NASAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.CongestionNasal == "false" ? "0" : oSurveyRequest.CongestionNasal;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_DIARREA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Diarrea == "false" ? "0" : oSurveyRequest.Diarrea;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_DIFIC_RESPIRA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DificultadRespiratoria == "false" ? "0" : oSurveyRequest.DificultadRespiratoria;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_DOLOR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Dolor == "false" ? "0" : oSurveyRequest.Dolor;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_DOLOR_GARGANTA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorGarganta == "false" ? "0" : oSurveyRequest.DolorGarganta;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_FIEBRE_ESCALOFRIO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.FiebreEscalofrio == "false" ? "0" : oSurveyRequest.FiebreEscalofrio;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_IRRITABILIDAD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.IrritabilidadConfusion == "false" ? "0" : oSurveyRequest.IrritabilidadConfusion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_MALESTAR_GENERAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.MalestarGeneral == "false" ? "0" : oSurveyRequest.MalestarGeneral;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_NAUSEAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.NauseasVomitos == "false" ? "0" : oSurveyRequest.NauseasVomitos;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_TOS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Tos == "false" ? "0" : oSurveyRequest.Tos;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_ABDOMINAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorAbdominal == "false" ? "0" : oSurveyRequest.DolorAbdominal;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_ARTICULACIONES_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorArticulaciones == "false" ? "0" : oSurveyRequest.DolorArticulaciones;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_MUSCULAR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorMuscular == "false" ? "0" : oSurveyRequest.DolorMuscular;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_PECHO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorPecho == "false" ? "0" : oSurveyRequest.DolorPecho;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_OTROS_SINTOMAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.OtrosSintomas == null ? "" : oSurveyRequest.OtrosSintomas;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_ASMA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Asma == "false" ? "0" : oSurveyRequest.Asma;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_CANCER_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Cancer == "false" ? "0" : oSurveyRequest.Cancer;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_DIABETES_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Diabetes == "false" ? "0" : oSurveyRequest.Diabetes;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_EMBARAZO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Embarazo == "false" ? "0" : oSurveyRequest.Embarazo;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_ENF_CARDIO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EnfCardiovascular == "false" ? "0" : oSurveyRequest.EnfCardiovascular;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_INMUNOSUPRESOR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EnfInmunosupresor == "false" ? "0" : oSurveyRequest.EnfInmunosupresor;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_ENF_PULMONAR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EnfPulmonarCronica == "false" ? "0" : oSurveyRequest.EnfPulmonarCronica;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_HIPERTENCION_ARTERIAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.HipertensionArterial == "false" ? "0" : oSurveyRequest.HipertensionArterial;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_INSUFICIENCIA_RENAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.InsuficienciaCronica == "false" ? "0" : oSurveyRequest.InsuficienciaCronica;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_MAYOR_60_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Mayor65 == "false" ? "0" : oSurveyRequest.Mayor65;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_OBESIDAD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Obesidad == "false" ? "0" : oSurveyRequest.Obesidad;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_PERSONAL_SALUD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.PersonalSalud == "false" ? "0" : oSurveyRequest.PersonalSalud;
            list.Add(value);

            list.Add(value);

            return list;
        }

        public List<InsertValuesRequest> BuildListSurveyMOLECULAR(SurveyRequest oSurveyRequest)
        {
            var list = new List<InsertValuesRequest>();
            var value = new InsertValuesRequest();

            value.ComponentFieldId = Constants.MOLECULAR_DOMICILIO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.TipoDomicilio;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_GEOLOCALIZACION_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Geolocalizacion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_PROFESION_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Profesion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_ES_PERSONAL_SALUD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EsPersonalSaludCbo;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_TIENE_SINTOMAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.TieneSintomas;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_INICIO_SINTOMAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.InicioSintomas;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_CEFALEA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Cefalea == "false" ? "0" : oSurveyRequest.Cefalea;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_CONGESTION_NASAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.CongestionNasal == "false" ? "0" : oSurveyRequest.CongestionNasal;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_DIARREA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Diarrea == "false" ? "0" : oSurveyRequest.Diarrea;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_DIFIC_RESPIRA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DificultadRespiratoria == "false" ? "0" : oSurveyRequest.DificultadRespiratoria;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_DOLOR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Dolor == "false" ? "0" : oSurveyRequest.Dolor;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_DOLOR_GARGANTA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorGarganta == "false" ? "0" : oSurveyRequest.DolorGarganta;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_FIEBRE_ESCALOFRIO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.FiebreEscalofrio == "false" ? "0" : oSurveyRequest.FiebreEscalofrio;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_IRRITABILIDAD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.IrritabilidadConfusion == "false" ? "0" : oSurveyRequest.IrritabilidadConfusion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_MALESTAR_GENERAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.MalestarGeneral == "false" ? "0" : oSurveyRequest.MalestarGeneral;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_NAUSEAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.NauseasVomitos == "false" ? "0" : oSurveyRequest.NauseasVomitos;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_TOS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Tos == "false" ? "0" : oSurveyRequest.Tos;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_ABDOMINAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorAbdominal == "false" ? "0" : oSurveyRequest.DolorAbdominal;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_ARTICULACIONES_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorArticulaciones == "false" ? "0" : oSurveyRequest.DolorArticulaciones;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_MUSCULAR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorMuscular == "false" ? "0" : oSurveyRequest.DolorMuscular;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_PECHO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.DolorPecho == "false" ? "0" : oSurveyRequest.DolorPecho;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_OTROS_SINTOMAS_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.OtrosSintomas == null ? "" : oSurveyRequest.OtrosSintomas;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_ASMA_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Asma == "false" ? "0" : oSurveyRequest.Asma;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_CANCER_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Cancer == "false" ? "0" : oSurveyRequest.Cancer;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_DIABETES_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Diabetes == "false" ? "0" : oSurveyRequest.Diabetes;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_EMBARAZO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Embarazo == "false" ? "0" : oSurveyRequest.Embarazo;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_ENF_CARDIO_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EnfCardiovascular == "false" ? "0" : oSurveyRequest.EnfCardiovascular;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_INMUNOSUPRESOR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EnfInmunosupresor == "false" ? "0" : oSurveyRequest.EnfInmunosupresor;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_ENF_PULMONAR_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.EnfPulmonarCronica == "false" ? "0" : oSurveyRequest.EnfPulmonarCronica;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_HIPERTENCION_ARTERIAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.HipertensionArterial == "false" ? "0" : oSurveyRequest.HipertensionArterial;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_INSUFICIENCIA_RENAL_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.InsuficienciaCronica == "false" ? "0" : oSurveyRequest.InsuficienciaCronica;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_MAYOR_60_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Mayor65 == "false" ? "0" : oSurveyRequest.Mayor65;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_OBESIDAD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.Obesidad == "false" ? "0" : oSurveyRequest.Obesidad;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_PERSONAL_SALUD_ID;
            value.ServiceComponentId = oSurveyRequest.ServiceComponentId;
            value.Value1 = oSurveyRequest.PersonalSalud == "false" ? "0" : oSurveyRequest.PersonalSalud;
            list.Add(value);

            list.Add(value);

            return list;
        }

        public List<InsertValuesRequest> BuildListLaboratoryANTIGENO(LaboratoryRequest oLaboratoryRequest)
        {
            var list = new List<InsertValuesRequest>();
            var value = new InsertValuesRequest();

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_CLASIFICACION_CLINICA_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ClasificacionClinica;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_FECHA_EJECUCION_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.FechaEjecucion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_PROCEDENCIA_SOLICITUD_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ProcedenciaSolicitud;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_RES_1_PRUEBA_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ResultadoPrimeraPrueba;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.ANTIGENO_RES_2_PRUEBA_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ResultadoSegundaPrueba;
            list.Add(value);


            list.Add(value);

            return list;
        }

        public List<InsertValuesRequest> BuildListLaboratoryMOLECULAR(LaboratoryRequest oLaboratoryRequest)
        {
            var list = new List<InsertValuesRequest>();
            var value = new InsertValuesRequest();

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_CLASIFICACION_CLINICA_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ClasificacionClinica;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_FECHA_EJECUCION_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.FechaEjecucion;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_PROCEDENCIA_SOLICITUD_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ProcedenciaSolicitud;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_RES_1_PRUEBA_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ResultadoPrimeraPrueba;
            list.Add(value);

            value = new InsertValuesRequest();
            value.ComponentFieldId = Constants.MOLECULAR_RES_2_PRUEBA_ID;
            value.ServiceComponentId = oLaboratoryRequest.ServiceComponentId;
            value.Value1 = oLaboratoryRequest.ResultadoSegundaPrueba;
            list.Add(value);


            list.Add(value);

            return list;
        }
    }
}
