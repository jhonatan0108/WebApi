using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Data;
using WebApi.Entities;
namespace WebApi.DAL
{
    public class DAL_Logs
    {
        public Entities.ObjResponse InsertLog(Log _objLog)
        {
            try
            {
                Data.Entities entities = new Data.Entities();
                ObjResponse _response = new ObjResponse();
                entities.Logs.Add(_objLog);
                if (entities.SaveChanges() > 0)
                {
                    _response.Message = "Se inserto Correctamente"; _response.Response = true;
                }
                else
                {
                    _response.Message = "Algo salio mal :( "; _response.Response = false;
                }
                return _response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error de DAL -"+ex.Message);
            }
        }
    }
}
