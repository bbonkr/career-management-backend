using System;

namespace CareerManagement.Models
{
    public class HttpResponseMessageModel
    {
        public HttpResponseMessageModel(int code = 200, string message = "")
        {
            this.Code = code;
            this.Message = message;
        }
        public string Message { get; private set; }

        public int Code { get; private set; }
    }
}
