using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using WebApi.Management;
namespace WebApi.BOL
{
    public class BOL_Usuarios
    {
        public Entities.ENT_Usuario RegisterUser(Entities.ENT_Usuario pUsuario)
        {
            TRN.TRN_Usuarios usuarios = new TRN.TRN_Usuarios();
            Entities.ENT_Usuario objuser = new Entities.ENT_Usuario();
            TRN.TRN_Utils utils = new TRN.TRN_Utils();
            //string passEncript = utils.Encriptar(pUsuario.PasswordHash);
            pUsuario.PasswordHash = utils.Encriptar(pUsuario.PasswordHash);
            try
            {
                int IdUser = usuarios.RegisterUser(Management.UsersBuilder.UsersBuilder.UserToEntity(pUsuario));
                //Busco usuario con el ID registrado
                objuser = Management.UsersBuilder.UsersBuilder.EntityToUser(usuarios.GetUserById(IdUser));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
            return objuser;
        }
    }
}
