using System.Net;

namespace PersonsAPI.Models
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }
}