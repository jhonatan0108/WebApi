using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class ObjLogModel
    {
        private bool _Status;
        private DateTime _DateTransaction = DateTime.MinValue;
        public bool Status { get => _Status; set => _Status = value; }
        public DateTime DateTransaction { get => _DateTransaction; set => _DateTransaction = value; }
    }
    public class ObjResponse
    {
        private string _Message = string.Empty;
        private bool _Response;
        public string Message { get => _Message; set => _Message = value; }
        public bool Response { get => _Response; set => _Response = value; }
    }
}
