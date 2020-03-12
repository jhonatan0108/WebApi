using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using WebApi;
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
        public ObjResponse InsertLOG(ObjLogModel pLog)
        {
            try
            {
                return new BOL.BOL_Logs().InsertLog(pLog);
            }
            catch (Exception ex)
            {
                return new ObjResponse()
                {
                    Response = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
