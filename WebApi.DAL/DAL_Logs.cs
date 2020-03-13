using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Data;
using WebApi.Entities;
namespace WebApi.DAL
{
    public class DAL_Logs
    {
        public ObjResponse InsertLog(Log _objLog)
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
                throw new Exception("Error de DAL -" + ex.Message);
            }
        }
        public List<Log> GetListLogs()
        {
            try
            {
                Data.Entities entities = new Data.Entities();
                List<Log> _ListLog = entities.Logs.OrderByDescending(x => x.date_transaction).ToList();
                return _ListLog;
            }
            catch (Exception ex)
            {
                throw new Exception("Error de DAL -" + ex.Message);
            }
        }
        public List<Log> GetListLogs(string startDate, string endDate)
        {
            try
            {
                Data.Entities entities = new Data.Entities();
                List<Log> list = new List<Log>();
                list = entities.Logs.SqlQuery("Select * from Log where convert(varchar,date_transaction,103) >= @startdt and convert(varchar,date_transaction,103) <= @enddt "
                            , new System.Data.SqlClient.SqlParameter("@startdt", startDate), new System.Data.SqlClient.SqlParameter("@enddt", endDate)).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error de DAL -" + ex.Message);
            }
        }
    }
}
