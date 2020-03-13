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
        private List<ObjLogModel> _ListLog;
        private string _Message = string.Empty;
        private bool _Response;
        public string Message { get => _Message; set => _Message = value; }
        public bool Response { get => _Response; set => _Response = value; }
        public List<ObjLogModel> ListLog { get => _ListLog; set => _ListLog = value; }
    }
    public class ObjFilterLogByDate
    {
        private string _StarDate = string.Empty;
        private string _EndDate = string.Empty;
        public string StarDate { get => _StarDate; set => _StarDate = value; }
        public string EndDate { get => _EndDate; set => _EndDate = value; }
    }
}
