using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;

namespace WebApi.TRN
{
    public class TRN_Usuarios
    {
        DAL.Data.UsuariosEntities usuariosEntities = new DAL.Data.UsuariosEntities();
        DAL.Data.Users _User = new DAL.Data.Users();
        public int RegisterUser(DAL.Data.Users pUser)
        {
            int pResp = 0;
            try
            {
                usuariosEntities.Users.Add(pUser);
                usuariosEntities.SaveChanges();
                pResp = pUser.ID;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.InnerException.InnerException.Message);
            }
            return pResp;
        }

        public DAL.Data.Users GetUserById(int Uid)
        {
            try
            {
                _User = usuariosEntities.Users.Where(x => x.ID == Uid).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return _User;
        }
    }
}