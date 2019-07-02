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
        bool pResp = false;

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

        public bool GetUserLogin(string User, string Password)
        {
            try
            {
                _User = usuariosEntities.Users.Where(x => x.UserName == User.ToUpper() && x.PasswordHash == Password).FirstOrDefault();
                if (_User != null)
                    pResp = true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return pResp;
        }
        public List<DAL.Data.Users> getUsers()
        {
            List<DAL.Data.Users> listUser = new List<DAL.Data.Users>();
            try
            {
                listUser = usuariosEntities.Users.ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return listUser;
        }
    }
}