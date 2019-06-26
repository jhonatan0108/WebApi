using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi;

namespace WebApi.Controllers
{
    public class UsuariosController : ApiController
    {
        [HttpPost]
        public Entities.ENT_ObjUser RegisterUser(Entities.ENT_Usuario usuario)
        {
            Entities.ENT_ObjUser objResp = new Entities.ENT_ObjUser();
            BOL.BOL_Usuarios _bolUser = new BOL.BOL_Usuarios();
            if (ModelState.IsValid)
            {
                try
                {
                    objResp.ent_Usuario = _bolUser.RegisterUser(usuario);
                    if (objResp.ent_Usuario != null)
                    {
                        objResp.Mensaje = "Se registro con Exito el Usuario";
                        objResp.pRespuesta = true;
                    }
                    else
                    {
                        objResp.Mensaje = "Se presento un inconveniente con el registro del usuario, por favor vuelva a intentar.";
                        objResp.pRespuesta = false;
                    }
                }
                catch (Exception ex)
                {
                    objResp.Mensaje = "No se pudo completar la peticion. " + ex.Message.ToString();
                    objResp.pRespuesta = false;
                }
            }
            return objResp;
        }
    }
}
