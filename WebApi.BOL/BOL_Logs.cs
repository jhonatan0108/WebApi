using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Management.UsersBuilder;

namespace WebApi.BOL
{
    public class BOL_Logs
    {
        public Entities.ObjResponse InsertLog(Entities.ObjLogModel objLog)
        {
            try
            {
                return new TRN.TRN_Logs().InsertLog(UsersBuilder.LogToEntity(objLog));
            }
            catch (Exception ex)
            {
                throw new Exception("Error en -" + ex.Message);
            }
        }
    }
}
