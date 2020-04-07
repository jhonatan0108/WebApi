using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using WebApi;
using WebApi.BOL;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [RoutePrefix("api/InsLog")]
    public class InsLOGController : ApiController
    {

        [AllowAnonymous]
        [Route("InsertLog")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public ObjResponse InsertLOG(ObjLogModel data_log)
        {
            try
            {
                //data_log.DateTransaction = DateTime.Now;
                return new BOL_Logs().InsertLog(data_log);
            }
            catch (Exception ex)
            {
                return new ObjResponse()
                {
                    Response = false,
                    Message = ex.Message,
                    ListLog = new List<ObjLogModel>()
                };
            }
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("GetListLogs")]
        public ObjResponse GetListLogs()
        {
            ObjResponse response = new ObjResponse();
            try
            {

                response.ListLog = new BOL_Logs().GetListLogs();
                if (response.ListLog != null)
                {
                    response.Message = "Se consulto con Exito la informacion";
                    response.Response = true;
                }
                else
                {
                    response.Message = "Se presento un inconveniente consultado la informacion, por favor vuelva a intentar.";
                    response.Response = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = "No se pudo completar la peticion. " + ex.Message.ToString();
                response.Response = false;
            }
            return response;
        }

        [HttpGet]
        [AcceptVerbs("POST")]
        [Route("GetListLogsByDate")]
        public ObjResponse GetListLogsByDate(ObjFilterLogByDate objFilter)
        {
            ObjResponse response = new ObjResponse();
            try
            {
                CultureInfo MyCultureInfo = new CultureInfo("es-CO");

                DateTime FecFin = DateTime.ParseExact(objFilter.EndDate, "dd/MM/yyyy", MyCultureInfo);
                DateTime FecIni = DateTime.ParseExact(objFilter.StarDate, "dd/MM/yyyy", MyCultureInfo);
                if (FecFin < FecIni)
                    throw new Exception("La Fecha final no puede ser menor a la fecha inicial");

                response.ListLog = new BOL_Logs().GetListLogs(FecIni, FecFin.AddDays(1), objFilter.Uid);
                if (response.ListLog != null)
                {
                    response.Message = "Se consulto con Exito la informacion";
                    response.Response = true;
                }
                else
                {
                    response.Message = "Se presento un inconveniente consultado la informacion, por favor vuelva a intentar.";
                    response.Response = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = "No se pudo completar la peticion. " + ex.Message.ToString();
                response.Response = false;
            }
            return response;
        }

    }
}
