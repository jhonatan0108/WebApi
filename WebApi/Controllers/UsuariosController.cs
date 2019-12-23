using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using WebApi;


namespace WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [AllowAnonymous]
    [RoutePrefix("api/Users")]

    public class UsuariosController : ApiController
    {
        BOL.BOL_Usuarios _bolUser = new BOL.BOL_Usuarios();
        Entities.ObjUserModel objResp = new Entities.ObjUserModel();
        bool pResp = false;

        [HttpPost]
        [AllowAnonymous]
        [Route("registerUser")]
        public Entities.ObjUserModel RegisterUser(Entities.UsuarioModel usuario)
        {
            //Pruebas de ramas
            if (ModelState.IsValid)
            {
                try
                {

                    objResp.User = _bolUser.RegisterUser(usuario);
                    if (objResp.User != null)
                    {
                        objResp.Message = "Se registro con Exito el Usuario";
                        objResp.Response = true;
                    }
                    else
                    {
                        objResp.Message = "Se presento un inconveniente con el registro del usuario, por favor vuelva a intentar.";
                        objResp.Response = false;
                    }
                }
                catch (Exception ex)
                {
                    objResp.Message = "No se pudo completar la peticion. " + ex.Message.ToString();
                    objResp.Response = false;
                }
            }
            else
            {
                objResp.Message = "Por favor envie todos los campos.";
                objResp.Response = false;
            }
            return objResp;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("loginUser")]
        public bool LoginUser(Entities.LoginUserModel pLogin)
        {
            try
            {
                pResp = _bolUser.GetUserLogin(pLogin.UserName, pLogin.Password);
            }
            catch (Exception)
            {
                return pResp;
            }
            return pResp;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [Route("getUsers")]

        public Entities.ListUsersModel getUsers()
        {
            Entities.ListUsersModel listUsers = new Entities.ListUsersModel();
            try
            {
                listUsers.Users = _bolUser.getUsers();
                if (listUsers.Users != null)
                {
                    listUsers.Message = "Se consulto con Exito la informacion";
                    listUsers.Response = true;
                }
                else
                {
                    listUsers.Message = "Se presento un inconveniente consultado la informacion, por favor vuelva a intentar.";
                    listUsers.Response = false;
                }
            }
            catch (Exception ex)
            {
                listUsers.Message = "No se pudo completar la peticion. " + ex.Message.ToString();
                listUsers.Response = false;
            }
            return listUsers;
        }
    }
}
