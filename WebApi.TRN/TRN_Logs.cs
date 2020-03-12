using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApi.TRN
{
    public class TRN_Logs
    {
        public Entities.ObjResponse InsertLog(DAL.Data.Log _objLog)
        {
            try
            {
                return new DAL.DAL_Logs().InsertLog(_objLog);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en TRN - "+ex.Message);
            }
        }
    }
}
