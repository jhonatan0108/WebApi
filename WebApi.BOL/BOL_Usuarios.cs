using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using WebApi.Management;
namespace WebApi.BOL
{
    /// <summary>
    /// 
    /// </summary>
    public class BOL_Usuarios
    {
        TRN.TRN_Usuarios usuarios = new TRN.TRN_Usuarios();
        Entities.UsuarioModel objuser = new Entities.UsuarioModel();
        TRN.TRN_Utils utils = new TRN.TRN_Utils();
        bool pResp = false;
        public Entities.UsuarioModel RegisterUser(Entities.UsuarioModel pUsuario)
        {
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

        public bool GetUserLogin(string User, string Password)
        {
            //Encripto la contraseña, para verificar con la registrada en la BD
            try
            {
                Password = utils.Encriptar(Password);
                pResp = usuarios.GetUserLogin(User, Password);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
            return pResp;
        }
    }
}
