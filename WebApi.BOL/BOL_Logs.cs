using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Management.UsersBuilder;
using WebApi.TRN;

namespace WebApi.BOL
{
    public class BOL_Logs
    {

        public List<ObjLogModel> GetListLogs()
        {
            try
            {
                return UsersBuilder.ListLogToEntity(new TRN_Logs().GetListLogs());
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BOL GetListLogs -" + ex.Message);
            }
        }
        public List<ObjLogModel> GetListLogs(DateTime startDate, DateTime endDate)
        {
            try
            {
                return UsersBuilder.ListLogToEntity(new TRN_Logs().GetListLogs(startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy")));
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BOL GetListLogs -" + ex.Message);
            }
        }

        public ObjResponse InsertLog(Entities.ObjLogModel objLog)
        {
            try
            {
                return new TRN_Logs().InsertLog(UsersBuilder.LogToEntity(objLog));
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BOL InsertLog-" + ex.Message);
            }
        }
    }
}
