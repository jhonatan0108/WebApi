using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
    }
    public class ResponseUser
    {
        private UsuarioModel _User;
        private bool _Response;
        private string _Message = string.Empty;

        public UsuarioModel User { get => _User; set => _User = value; }
        public bool Response { get => _Response; set => _Response = value; }
        public string Message { get => _Message; set => _Message = value; }
    }
}
