using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL;
using WebApi.Entities;

namespace WebApi.TRN
{
    public class TRN_Logs
    {
        public ObjResponse InsertLog(DAL.Data.Log _objLog)
        {
            try
            {
                return new DAL_Logs().InsertLog(_objLog);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en TRN InsertLog - " + ex.Message);
            }
        }
        public List<DAL.Data.Log> GetListLogs()
        {
            try
            {
                return new DAL_Logs().GetListLogs();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en TRN GetListLogs - " + ex.Message);
            }
        }
        public List<DAL.Data.Log> GetListLogs(string startDate, string endDate)
        {
            try
            {
                return new DAL_Logs().GetListLogs(startDate, endDate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en TRN GetListLogs - " + ex.Message);
            }
        }
    }
}
