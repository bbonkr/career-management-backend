namespace CareerManagement.Models
{
    public class HttpResponseWithDataModel<T> : HttpResponseMessageModel
    {
        public HttpResponseWithDataModel():base(200, "") { }
        public T Data { get; set; }
    }
}
