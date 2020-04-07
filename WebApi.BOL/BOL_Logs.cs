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
                throw new Exception(ex.Message);
            }
        }
        public List<ObjLogModel> GetListLogs(DateTime startDate, DateTime endDate, int Uid)
        {
            try
            {
                return UsersBuilder.ListLogToEntity(new TRN_Logs().GetListLogs(startDate.ToString("yyyy/MM/dd"), endDate.ToString("yyyy/MM/dd"), Uid));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ObjResponse InsertLog(ObjLogModel objLog)
        {
            try
            {
                return new TRN_Logs().InsertLog(UsersBuilder.LogToEntity(objLog));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
