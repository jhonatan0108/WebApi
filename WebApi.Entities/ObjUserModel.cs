using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class ObjUserModel
    {
        public UsuarioModel User { get; set; }
        public string Message { get; set; }
        public bool Response { get; set; }
    }
}
