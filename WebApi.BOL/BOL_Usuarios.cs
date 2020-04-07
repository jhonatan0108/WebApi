using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebApi;
using WebApi.Entities;
using WebApi.Management;
using WebApi.Management.UsersBuilder;

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
        public Entities.UsuarioModel RegisterUser(Entities.UsuarioModel pUsuario)
        {
            try
            {
                pUsuario.PasswordHash = Crypto.HashPassword(pUsuario.PasswordHash);
                int IdUser = usuarios.RegisterUser(UsersBuilder.UserToEntity(pUsuario));
                //Busco usuario con el ID registrado
                objuser = UsersBuilder.EntityToUser(usuarios.GetUserById(IdUser));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
            return objuser;
        }
        public ResponseUser GetUserLogin(string User, string Password)
        {
            try
            {
                //Busco el Usuario con el fin de comparar SI es valido o NO
                objuser = UsersBuilder.EntityToUser(usuarios.GetUserByUser(User));
                if (objuser != null)
                {
                    if (Crypto.VerifyHashedPassword(objuser.PasswordHash, Password))
                    {
                        ResponseUser objres = new ResponseUser();
                        objres.User = objuser;
                        objres.Response = true;
                        objres.Message = "Consultado con Exito";
                        return objres;
                    }
                    else
                    {
                        ResponseUser objres = new ResponseUser();
                        objres.User = objuser;
                        objres.Response = false;
                        objres.Message = "La contraseña no corresponde.";
                        return objres;
                    }
                }
                else
                {
                    ResponseUser objres = new ResponseUser();
                    objres.User = objuser;
                    objres.Response = false;
                    objres.Message = "No se encontro informacion del usuario.";
                    return objres;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
        }
        public List<Entities.UsuarioModel> getUsers()
        {
            List<Entities.UsuarioModel> listUsers = new List<Entities.UsuarioModel>();
            try
            {
                listUsers = UsersBuilder.ListEntityToUser(usuarios.getUsers());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message.ToString());
            }
            return listUsers;
        }
    }
}
