namespace PersonsAPI.Models
{
    public class BaseApiResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}